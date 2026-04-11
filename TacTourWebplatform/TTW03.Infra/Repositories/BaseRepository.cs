using System;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly TacTourDbContext context;
    public BaseRepository (TacTourDbContext context)
    {
        this.context = context;
    }


//* 1º MÉTODO DO CRUD - ACTUALIZAR
    public async Task<string> Actualizar(T model)
    {
        context.Set<T>().Update(model);
        return await context.SaveChangesAsync() > 0 ?
            "Registo actualizado com sucesso" :
            "Não foi possível actualizar o Registo";
    }

//* 2º MÉTODO DO CRUD - CADASTRAR
    public async Task<string> Cadastrar(T model)
    {
        await context.Set<T>().AddAsync(model);
        return await context.SaveChangesAsync() > 0 ?
            "Registo cadastrado com sucesso" :
            "Não foi possível cadastrar o Registo";
    }

//* 3º MÉTODO DO CRUD - DELETAR
    public async Task<string> Deletar(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);

        if(entity == null)
            return "Registo não encontrado";

        context.Set<T>().Remove(entity);

        var resultado = await context.SaveChangesAsync();

        return resultado > 0 ?
            "Registo eliminado com sucesso" :
            "Não foi possível eliminar o Registo";
    }

//* 4º MÉTODO DO CRUD - LISTAGEM
    public async Task<IEnumerable<T>> Listagem()
    {
        return await context.Set<T>().ToListAsync();
    }

//* 5º MÉTODO DO CRUD - PESQUISAR POR ID
    public async Task<T?> PesquisarPorId(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }

}