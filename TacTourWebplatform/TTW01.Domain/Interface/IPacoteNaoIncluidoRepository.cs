using System;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteNaoIncluido;


namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IPacoteNaoIncluidoRepository : IRepository<PacoteNaoIncluidoEntity>
{
    Task<IEnumerable<PacoteNaoIncluidoEntity>> ListarPorPacote(int idPacote);
}