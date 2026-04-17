using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Domain.Entities;
using TacTourWebplatform.Domain.Interfaces;
using TacTourWebplatform.Infrastructure.Data;

namespace TacTourWebplatform.Application.Reservas;

public class ReservaService(IReservaRepository repositorio, TacTourDbContext contexto)
{
    private const string Pendente = "pendente";
    private const string AguardaPagamento = "aguardando_pagamento";
    private const string Confirmada = "confirmada";
    private const string Concluida = "concluida";

    private static string Norm(string s) => s.Trim().ToLowerInvariant();

    private static ReservaListagemResponse Mapear(Reserva r)
    {
        var url = r.Pagamento?.ComprovativoUrl?.Trim() ?? string.Empty;
        return new ReservaListagemResponse
        {
            Id = r.Id,
            IdPacote = r.IdPacote,
            TituloPacote = r.Pacote?.Titulo ?? string.Empty,
            NomeCliente = r.Usuario?.Nome ?? string.Empty,
            Email = r.Usuario?.Email ?? string.Empty,
            DataSolicitacao = r.DataSolicitacao.ToString("yyyy-MM-dd"),
            Pessoas = r.QuantidadePessoas,
            PrecoTotal = r.PrecoTotal,
            EstadoReserva = Norm(r.EstadoReserva),
            ComprovativoEnviado = !string.IsNullOrEmpty(url),
        };
    }

    public async Task<List<ReservaListagemResponse>> ListarAsync(string? estado, string? texto)
    {
        var lista = (await repositorio.ListarComDetalhesAsync()).ToList();
        if (!string.IsNullOrWhiteSpace(estado))
        {
            var e = Norm(estado);
            lista = lista.Where(r => Norm(r.EstadoReserva) == e).ToList();
        }

        if (!string.IsNullOrWhiteSpace(texto))
        {
            var t = texto.Trim().ToLowerInvariant();
            lista = lista.Where(r =>
                (r.Usuario?.Nome.ToLowerInvariant().Contains(t) ?? false) ||
                (r.Usuario?.Email.ToLowerInvariant().Contains(t) ?? false) ||
                (r.Pacote?.Titulo.ToLowerInvariant().Contains(t) ?? false)).ToList();
        }

        return lista.Select(Mapear).ToList();
    }

    public async Task<ReservaListagemResponse?> ObterAsync(int id)
    {
        var r = await repositorio.ObterComDetalhesAsync(id);
        return r == null ? null : Mapear(r);
    }

    public async Task<string> PedirPagamentoAsync(int id)
    {
        var r = await repositorio.ObterParaEdicaoAsync(id);
        if (r == null)
            return "Reserva não encontrada";

        if (Norm(r.EstadoReserva) != Pendente)
            return "Estado inválido para esta acção";

        r.EstadoReserva = AguardaPagamento;
        r.Pagamento ??= new Pagamento
        {
            IdReserva = r.Id,
            ComprovativoUrl = string.Empty,
            EstadoPagamento = "pendente",
            DataPagamento = DateTime.UtcNow,
            DataConfirmacao = DateTime.MinValue,
        };

        await repositorio.GuardarAlteracoesAsync(r);
        return "sucesso";
    }

    public async Task<string> SimularComprovativoAsync(int id)
    {
        var r = await repositorio.ObterParaEdicaoAsync(id);
        if (r == null)
            return "Reserva não encontrada";

        if (Norm(r.EstadoReserva) != AguardaPagamento)
            return "Estado inválido para esta acção";

        r.Pagamento ??= new Pagamento
        {
            IdReserva = r.Id,
            EstadoPagamento = "pendente",
            DataPagamento = DateTime.UtcNow,
            DataConfirmacao = DateTime.MinValue,
        };

        r.Pagamento.ComprovativoUrl = "https://api.tactour.local/comprovativos/mock.pdf";
        r.Pagamento.DataPagamento = DateTime.UtcNow;
        await repositorio.GuardarAlteracoesAsync(r);
        return "sucesso";
    }

    public async Task<string> ValidarComprovativoAsync(int id)
    {
        var r = await repositorio.ObterParaEdicaoAsync(id);
        if (r == null)
            return "Reserva não encontrada";

        if (Norm(r.EstadoReserva) != AguardaPagamento)
            return "Estado inválido para esta acção";

        if (r.Pagamento == null || string.IsNullOrWhiteSpace(r.Pagamento.ComprovativoUrl))
            return "Comprovativo não encontrado";

        r.EstadoReserva = Confirmada;
        r.Pagamento.EstadoPagamento = "confirmado";
        r.Pagamento.DataConfirmacao = DateTime.UtcNow;
        await repositorio.GuardarAlteracoesAsync(r);
        return "sucesso";
    }

    public async Task<string> MarcarConcluidaAsync(int id)
    {
        var r = await repositorio.ObterParaEdicaoAsync(id);
        if (r == null)
            return "Reserva não encontrada";

        if (Norm(r.EstadoReserva) != Confirmada)
            return "Estado inválido para esta acção";

        r.EstadoReserva = Concluida;
        await repositorio.GuardarAlteracoesAsync(r);
        return "sucesso";
    }

    public async Task<(int id, string mensagem)> CriarAsync(CriarReservaRequest dto)
    {
        var pacote = await contexto.Pacotes.AsNoTracking().FirstOrDefaultAsync(p => p.Id == dto.IdPacote);
        if (pacote == null)
            return (0, "Pacote não encontrado");

        var usuario = await contexto.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == dto.IdUsuario);
        if (usuario == null)
            return (0, "Utilizador não encontrado");

        var preco = pacote.PrecoBase * dto.QuantidadePessoas;
        var reserva = new Reserva
        {
            IdPacote = dto.IdPacote,
            IdUsuario = dto.IdUsuario,
            QuantidadePessoas = dto.QuantidadePessoas,
            PrecoTotal = preco,
            TipoReserva = string.IsNullOrWhiteSpace(dto.TipoReserva) ? "normal" : dto.TipoReserva.Trim(),
            EstadoReserva = Pendente,
            DataSolicitacao = DateTime.UtcNow,
        };

        var msg = await repositorio.Cadastrar(reserva);
        return msg.Contains("sucesso") ? (reserva.Id, msg) : (0, msg);
    }
}
