using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Domain.Entities;
using TacTourWebplatform.Domain.Interfaces;
using TacTourWebplatform.Infrastructure.Data;

namespace TacTourWebplatform.Infrastructure.Repositories;

public class UsuarioRepository(TacTourDbContext context) : BaseRepository<Usuario>(context), IUsuarioRepository
{
    public async Task<Usuario?> BuscarPorEmail(string email)
    {
        var e = email.Trim().ToLower();
        return await Context.Usuarios.FirstOrDefaultAsync(u => u.Email.ToLower() == e);
    }

    public async Task<bool> EmailExiste(string email)
    {
        var e = email.Trim().ToLower();
        return await Context.Usuarios.AnyAsync(u => u.Email.ToLower() == e);
    }

    public async Task<IEnumerable<Usuario>> ListarPorPerfil(int idPerfil)
    {
        return await Context.Usuarios.Where(u => u.IdPerfil == idPerfil).ToListAsync();
    }

    public async Task<IEnumerable<Usuario>> ListarEquipaAgenciaAsync()
    {
        var perfis = new[] { "admin", "moderador", "gestor", "administrador" };
        return await Context.Usuarios
            .AsNoTracking()
            .Include(u => u.Perfil)
            .Where(u => u.Perfil != null && perfis.Contains(u.Perfil.TipoPerfil.ToLower()))
            .OrderBy(u => u.Nome)
            .ToListAsync();
    }
}
