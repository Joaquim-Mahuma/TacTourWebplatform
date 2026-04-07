using System;
using TacTourWebplatform.TTW01.Domain.Entities.Actividade;


namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IActividadeRepository : IRepository<ActividadeEntity>
{
    Task<IEnumerable<ActividadeEntity>> ListarPorDestino(int idDestino);
}