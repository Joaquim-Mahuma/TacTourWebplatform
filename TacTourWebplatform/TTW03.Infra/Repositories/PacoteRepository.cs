using System;
using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class PacoteRepository(TacTourDbContext context) : ICadastrarRepository<PacoteEntity>,
                                                            IListagemRepository<PacoteEntity>,
                                                            IPesquisarRepository<PacoteEntity>,
                                                            IActualizarRepository<PacoteEntity>,
                                                            IApagarRepository<PacoteEntity>

{
    public async Task<string> Actualizar(PacoteEntity model)
    {
        context.TabelaPacoteTuristico.Update(model);
        return await context.SaveChangesAsync() > 0 ?
        "Pacote actualizado com sucesso" :
        "Não foi possível actualizar o Pacote";
    }

    public async Task<string> Apagar(PacoteEntity model)
    {
        context.TabelaPacoteTuristico.Remove(model);
        return await context.SaveChangesAsync() > 0 ?
        "Pacote apagado com sucesso" :
        "Não foi possível apagar o Pacote";

    }

    public async Task<string> Cadastrar(PacoteEntity model)
    {
        await context.TabelaPacoteTuristico.AddAsync(model);
        return await context.SaveChangesAsync() > 0 ?
        "Pacote cadastrado com sucesso" :
        "Não foi possível cadastrar o Pacote";

    }

    public async Task<IEnumerable<PacoteEntity>> Listagem()
    {
        return await context.TabelaPacoteTuristico.Include(pacote => pacote.Imagens).ToListAsync();

    }

    public async Task<PacoteEntity?> Pesquisar(int id)
    {
        return await context.TabelaPacoteTuristico.Include(pacote => pacote.Imagens).FirstOrDefaultAsync(x => x.Id == id);
    }
}
