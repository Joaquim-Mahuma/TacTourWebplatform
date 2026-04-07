using System;
using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class TipoDestinoRepository(TacTourDbContext context) : IRepository<TipoDestinoEntity>
{
    public async Task<string> Actualizar(TipoDestinoEntity model)
    {
        context.TabelaTipoDestino.Update(model);
        return await context.SaveChangesAsync() > 0 ?
            "Tipo de Destino cadastrado com sucesso" :
            "Não foi possível cadasstar o Tipo de Destino";
    }

    public async Task<string> Cadastrar(TipoDestinoEntity model)
    {
        await context.TabelaTipoDestino.AddAsync(model);
        return await context.SaveChangesAsync() > 0 ?
            "Tipo de Destino cadastrado com sucesso" :
            "Não foi possível cadasstar o Tipo de Destino";
    }

    public async Task<string> Deletar(TipoDestinoEntity model)
    {
        context.TabelaTipoDestino.Remove(model);
        return await context.SaveChangesAsync() > 0 ?
            "Tipo de Destino eliminado com sucesso" :
            "Não foi possível eliminar o Tipo de Destino";
    }

    public async Task<IEnumerable<TipoDestinoEntity>> Listagem()
    {
        return await context.TabelaTipoDestino.ToListAsync();
    }

    public async Task<TipoDestinoEntity?> PesquisarPorId(int id)
    {
        return await context.TabelaTipoDestino.FindAsync(id);
    }

    public async Task<TipoDestinoEntity?> PesquisarPorTexto(string texto)
    {
        return await context.TabelaTipoDestino
        .FirstOrDefaultAsync(td => td.TipoDestino.Contains(texto));
    }
}
