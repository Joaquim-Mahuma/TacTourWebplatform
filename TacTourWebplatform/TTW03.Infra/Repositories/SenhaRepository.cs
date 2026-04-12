using System;
using TacTourWebplatform.TTW01.Domain.Entities.Senha;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;


namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class SenhaRepository : BaseRepository<SenhaEntity>, ISenhaRepository
{
    //* CONSTRUTOR (TODO MÉTODO TEM)
    public SenhaRepository(TacTourDbContext context) : base(context) { }

    public async Task<(string message, int id)> CadastrarSenha(SenhaEntity entity)
    {
        await context.TabelaSenha.AddAsync(entity);
        return await context.SaveChangesAsync() > 0
        ? ("Senha cadastrada com sucesso", entity.Id)
        : ("Erro no cadastro", 0);
    }
}
