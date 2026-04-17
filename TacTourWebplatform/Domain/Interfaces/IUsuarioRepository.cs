using TacTourWebplatform.Domain.Entities;

namespace TacTourWebplatform.Domain.Interfaces;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario?> BuscarPorEmail(string email);

    Task<bool> EmailExiste(string email);

    Task<IEnumerable<Usuario>> ListarPorPerfil(int idPerfil);

    Task<IEnumerable<Usuario>> ListarEquipaAgenciaAsync();
}
