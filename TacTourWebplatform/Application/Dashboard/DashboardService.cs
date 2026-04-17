using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Application.Reservas;
using TacTourWebplatform.Infrastructure.Data;

namespace TacTourWebplatform.Application.Dashboard;

public class DashboardService(TacTourDbContext contexto)
{
    public async Task<DashboardMetricasResponse> ObterMetricasAsync()
    {
        var ativos = await contexto.Pacotes
            .CountAsync(p => p.Estado.ToLower() == "ativo" || p.Estado.ToLower() == "activo");

        var reservasCurso = await contexto.Reservas
            .CountAsync(r =>
                r.EstadoReserva.ToLower() != "concluida" &&
                r.EstadoReserva.ToLower() != "concluída");

        var valor = await contexto.Reservas
            .Where(r =>
                r.EstadoReserva.ToLower() == "confirmada" ||
                r.EstadoReserva.ToLower() == "aguardando_pagamento")
            .SumAsync(r => (decimal?)r.PrecoTotal) ?? 0m;

        return new DashboardMetricasResponse
        {
            PacotesAtivos = ativos,
            ReservasEmCurso = reservasCurso,
            ValorEmConfirmacao = valor,
        };
    }

    public async Task<DashboardResumoResponse> ObterResumoAsync(int limite)
    {
        var metricas = await ObterMetricasAsync();
        var take = limite <= 0 ? 8 : Math.Min(limite, 50);
        var lista = await contexto.Reservas
            .AsNoTracking()
            .Include(r => r.Pacote)
            .Include(r => r.Usuario)
            .Include(r => r.Pagamento)
            .OrderByDescending(r => r.DataSolicitacao)
            .Take(take)
            .ToListAsync();

        var recentes = lista.Select(r =>
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
                EstadoReserva = r.EstadoReserva.Trim().ToLowerInvariant(),
                ComprovativoEnviado = !string.IsNullOrEmpty(url),
            };
        }).ToList();

        return new DashboardResumoResponse { Metricas = metricas, ReservasRecentes = recentes };
    }
}
