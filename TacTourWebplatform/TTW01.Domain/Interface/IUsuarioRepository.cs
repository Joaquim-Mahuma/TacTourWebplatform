using System;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;

namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IUsuarioRepository : IRepository<UsuarioEntity>
{
    Task<UsuarioEntity?> BuscarPorEmail(string email);

    Task<bool> EmailExiste(string email);

    Task<IEnumerable<UsuarioEntity>> ListarPorPerfil(int idPerfil);
}
