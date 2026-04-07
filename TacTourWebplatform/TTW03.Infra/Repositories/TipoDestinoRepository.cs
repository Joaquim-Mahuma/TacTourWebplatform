using System;
using TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class TipoDestinoRepository(TacTourDbContext context) : IRepository<TipoDestinoEntity>
{
    public async Task<string> Actualizar(TipoDestinoEntity model)
    {
        await context.TabelaTipoDestino.Update(TipoDestinoEntity model)
        return await context.
    }

    public async Task<string> Cadastrar(TipoDestinoEntity model)
    {
        await context.TabelaTipoDestino.AddAsync(model);
        return await context.SaveChangesAsync() > 0 ?
            "Tipo de Destino cadastrado com sucesso" :
            "Não foi possível cadasstar o Tipo de Destino";
    }

    public async Task<string> Deletar(TipoDestinoEntity id)
    {
        context.TabelaTipoDestino.Remove(id);
        return await context.SaveChangesAsync() > 0 ?
            "Tipo de Destino eliminado com sucesso" :
            "Não foi possível eliminar o Tipo de Destino";
    }

    public Task<IEnumerable<TipoDestinoEntity>> Listagem()
    {
        
    }

    public Task<TipoDestinoEntity?> PesquisarPorId(int id)
    {
        
    }

    public Task<TipoDestinoEntity> PesquisarPorTexto(string text)
    {
        
    }
}
