using System;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteIncluido;


namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IPacoteIncluidoRepository : IRepository<PacoteIncluidoEntity>
{
    Task<IEnumerable<PacoteIncluidoEntity>> ListarPorPacote(int idPacote);
}
