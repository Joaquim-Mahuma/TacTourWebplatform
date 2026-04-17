using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Domain.Interfaces;
using TacTourWebplatform.Infrastructure.Data;

namespace TacTourWebplatform.Infrastructure.Repositories;

public class BaseRepository<T>(TacTourDbContext context) : IRepository<T> where T : class
{
    protected readonly TacTourDbContext Context = context;

    public async Task<string> Actualizar(T model)
    {
        Context.Set<T>().Update(model);
        return await Context.SaveChangesAsync() > 0
            ? "Registo actualizado com sucesso"
            : "Não foi possível actualizar o Registo";
    }

    public async Task<string> Cadastrar(T model)
    {
        await Context.Set<T>().AddAsync(model);
        return await Context.SaveChangesAsync() > 0
            ? "Registo cadastrado com sucesso"
            : "Não foi possível cadastrar o Registo";
    }

    public async Task<string> Deletar(int id)
    {
        var entity = await Context.Set<T>().FindAsync(id);
        if (entity == null)
            return "Registo não encontrado";

        Context.Set<T>().Remove(entity);
        var resultado = await Context.SaveChangesAsync();
        return resultado > 0
            ? "Registo eliminado com sucesso"
            : "Não foi possível eliminar o Registo";
    }

    public async Task<IEnumerable<T>> Listagem()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task<T?> PesquisarPorId(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }
}
