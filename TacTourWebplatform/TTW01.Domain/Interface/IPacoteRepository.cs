using System;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;

namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IPacoteRepository : IRepository<PacoteEntity>
{
    //* Método
    Task<IEnumerable<PacoteEntity>> ObterPacotesActivos();


}
