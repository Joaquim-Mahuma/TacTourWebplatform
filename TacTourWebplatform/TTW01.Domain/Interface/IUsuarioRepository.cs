using System;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;

namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IUsuarioRepository : IRepository<UsuarioEntity>
{
    Task<(string message, int id)> CadastrarUsuario(UsuarioEntity entity);

    Task<UsuarioEntity?> PesquisarPorEmail(string email);
    
    Task<IEnumerable<UsuarioEntity>> ListarPorPerfil(int idPerfil);

/*

    Task<bool> EmailExiste(string email);

*/
}
