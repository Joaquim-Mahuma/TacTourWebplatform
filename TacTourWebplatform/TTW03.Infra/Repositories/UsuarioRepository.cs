using System;
using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
{
    //* CONSTRUTOR (TODO MÉTODO TEM)
    public UsuarioRepository(TacTourDbContext context) : base(context) { }

    public async Task<(string message, int id)> CadastrarUsuario(UsuarioEntity entity)
    {
        await context.TabelaUsuario.AddAsync(entity);
        return await context.SaveChangesAsync() > 0
        ? ("Usuário cadastrado com sucesso", entity.Id)
        : ("Erro no cadastro", 0);
    }


    public async Task<UsuarioEntity?> PesquisarPorEmail(string email)
    {
        var usuario = await context.TabelaUsuario.FirstOrDefaultAsync(u => u.Email == email);

        return usuario;
    }
}
