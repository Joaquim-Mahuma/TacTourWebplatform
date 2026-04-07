using System;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;

namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IPacoteRepository : IRepository<PacoteEntity>
{

    Task<IEnumerable<PacoteEntity>> ListarPacotesActivos();

    Task<IEnumerable<PacoteEntity>> ListarPacotesPorDestino(int idDestino);

    Task<IEnumerable<PacoteEntity>> ListarPacotesPorNome(string nome);

    Task<IEnumerable<PacoteEntity>> ListarPacotesPorOperador(int idOperador);

}
