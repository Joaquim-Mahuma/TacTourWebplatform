using System;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteInfo;


namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IPacoteInfoRepository : IRepository<PacoteInfoEntity>
{
    Task<IEnumerable<PacoteInfoEntity>> ListarPorPacote(int idPacote);
}