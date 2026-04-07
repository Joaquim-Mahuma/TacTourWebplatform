using System;
using TacTourWebplatform.TTW01.Domain.Entities.Itinerario;


namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IItinerarioRepository : IRepository<ItinerarioEntity>
{
    Task<IEnumerable<ItinerarioEntity>> ListarPorPacote(int idPacote);
}