using System;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;

namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IPacoteRepository : IRepository<PacoteEntity>
{

    Task<IEnumerable<PacoteEntity>> ObterPacotesActivos();

    Task<> ObterPacotesPorDestino();

}
