using TacTourWebplatform.Domain.Entities;
using TacTourWebplatform.Domain.Interfaces;

namespace TacTourWebplatform.Application.Pacotes;

public class PacoteService(IPacoteRepository repositorio)
{
    private static PacoteListagemResponse MapearListagem(Pacote p)
    {
        var img = p.Imagens.OrderBy(i => i.Id).FirstOrDefault()?.UrlImagem ?? string.Empty;
        return new PacoteListagemResponse
        {
            Id = p.Id,
            Titulo = p.Titulo,
            Descricao = p.Descricao,
            PrecoBase = p.PrecoBase,
            DataInicio = p.DataInicio.ToString("yyyy-MM-dd"),
            DataFim = p.DataFim.ToString("yyyy-MM-dd"),
            DuracaoDias = p.Duracao,
            Estado = NormalizarEstadoPacote(p.Estado),
            ImagemUrl = img,
            IdOperador = p.IdOperador,
        };
    }

    private static string NormalizarEstadoPacote(string estado)
    {
        var e = estado.Trim().ToLowerInvariant();
        return e switch
        {
            "activo" or "ativo" => "ativo",
            "inactivo" or "inativo" => "inativo",
            "rascunho" or "draft" => "rascunho",
            _ => e,
        };
    }

    public async Task<List<PacoteListagemResponse>> ListarAsync(string? estado)
    {
        var lista = await repositorio.ListarComImagensAsync();
        if (!string.IsNullOrWhiteSpace(estado))
        {
            var alvo = estado.Trim().ToLowerInvariant();
            lista = lista.Where(p => NormalizarEstadoPacote(p.Estado) == alvo);
        }

        return lista.Select(MapearListagem).ToList();
    }

    public async Task<PacoteDetalheResponse?> ObterAsync(int id)
    {
        var p = await repositorio.ObterComRelacoesAsync(id);
        if (p == null)
            return null;

        var baseDto = MapearListagem(p);
        return new PacoteDetalheResponse
        {
            Id = baseDto.Id,
            Titulo = baseDto.Titulo,
            Descricao = baseDto.Descricao,
            PrecoBase = baseDto.PrecoBase,
            DataInicio = baseDto.DataInicio,
            DataFim = baseDto.DataFim,
            DuracaoDias = baseDto.DuracaoDias,
            Estado = baseDto.Estado,
            ImagemUrl = baseDto.ImagemUrl,
            IdOperador = baseDto.IdOperador,
            Imagens = p.Imagens.OrderBy(i => i.Id).Select(i => i.UrlImagem).ToList(),
            Incluidos = p.ItensIncluidos.OrderBy(i => i.Ordem)
                .Select(i => new ItemOrdenadoResponse { Ordem = i.Ordem, Descricao = i.Descricao }).ToList(),
            NaoIncluidos = p.ItensNaoIncluidos.OrderBy(i => i.Ordem)
                .Select(i => new ItemOrdenadoResponse { Ordem = i.Ordem, Descricao = i.Descricao }).ToList(),
            Informacoes = p.InfoImportantes.OrderBy(i => i.Ordem)
                .Select(i => new ItemOrdenadoResponse { Ordem = i.Ordem, Descricao = i.Descricao }).ToList(),
            Itinerario = p.Itinerarios.OrderBy(i => i.Ordem)
                .Select(i => new ItinerarioResponse { Ordem = i.Ordem, DestinoNome = i.Destino?.Nome }).ToList(),
        };
    }

    public async Task<(int id, string mensagem)> CriarAsync(CriarPacoteRequest dto)
    {
        if (!DateOnly.TryParseExact(dto.DataInicio, "yyyy-MM-dd", out var di) ||
            !DateOnly.TryParseExact(dto.DataFim, "yyyy-MM-dd", out var df))
        {
            return (0, "Datas inválidas");
        }
        


        var dur = dto.DuracaoDias > 0 ? dto.DuracaoDias : Math.Max(1, df.DayNumber - di.DayNumber + 1);
        var pacote = new Pacote
        {
            Titulo = dto.Titulo.Trim(),
            Descricao = dto.Descricao.Trim(),
            PrecoBase = dto.PrecoBase,
            DataInicio = di,
            DataFim = df,
            Duracao = dur,
            PontoEncontro = dto.PontoEncontro.Trim(),
            PontoLargada = dto.PontoLargada.Trim(),
            Estado = NormalizarEstadoPacote(dto.Estado),
            IdOperador = dto.IdOperador <= 0 ? 1 : dto.IdOperador,
        };

        var msg = await repositorio.Cadastrar(pacote);
        if (!msg.Contains("sucesso"))
            return (0, msg);

        if (!string.IsNullOrWhiteSpace(dto.ImagemUrl))
            await repositorio.AdicionarImagemAsync(pacote.Id, dto.ImagemUrl.Trim(), string.Empty);

        return (pacote.Id, msg);
    }

    public async Task<string> AlterarEstadoAsync(int id, AlterarEstadoPacoteRequest dto)
    {
        var p = await repositorio.PesquisarPorId(id);
        if (p == null)
            return "Registo não encontrado";

        p.Estado = NormalizarEstadoPacote(dto.Estado);
        return await repositorio.Actualizar(p);
    }
}
