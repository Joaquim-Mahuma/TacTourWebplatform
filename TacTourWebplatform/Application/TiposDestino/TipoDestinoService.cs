using TacTourWebplatform.Domain.Entities;
using TacTourWebplatform.Domain.Interfaces;

namespace TacTourWebplatform.Application.TiposDestino;

public class TipoDestinoService(ITipoDestinoRepository repositorio)
{
    public async Task<string> CriarAsync(CriarTipoDestinoRequest dto)
    {
        var entidade = new TipoDestino { Nome = dto.Nome };
        return await repositorio.Cadastrar(entidade);
    }

    public async Task<string> AtualizarAsync(int id, AtualizarTipoDestinoRequest dto)
    {
        var entidade = await repositorio.PesquisarPorId(id);
        if (entidade == null)
            return "Registo não encontrado";

        entidade.Nome = dto.Nome;
        return await repositorio.Actualizar(entidade);
    }

    public async Task<string> EliminarAsync(int id)
    {
        return await repositorio.Deletar(id);
    }

    public async Task<List<TipoDestinoResponse>> ListarAsync()
    {
        var lista = await repositorio.Listagem();
        return lista.Select(t => new TipoDestinoResponse { Id = t.Id, Nome = t.Nome }).ToList();
    }

    public async Task<TipoDestinoResponse?> ObterPorIdAsync(int id)
    {
        var t = await repositorio.PesquisarPorId(id);
        return t == null ? null : new TipoDestinoResponse { Id = t.Id, Nome = t.Nome };
    }

    public async Task<TipoDestinoResponse?> PesquisarPorTextoAsync(string texto)
    {
        var t = await repositorio.PesquisarPorTexto(texto);
        return t == null ? null : new TipoDestinoResponse { Id = t.Id, Nome = t.Nome };
    }
}
