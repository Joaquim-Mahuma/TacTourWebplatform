using TacTourWebplatform.Domain.Entities;

namespace TacTourWebplatform.Domain.Interfaces;

public interface IDestinoRepository : IRepository<Destino>
{
    Task<IEnumerable<Destino>> ListarPorTipo(int idTipo);
}
