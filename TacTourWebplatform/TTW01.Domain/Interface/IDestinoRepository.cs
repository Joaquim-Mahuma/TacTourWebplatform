using System;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;


namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IDestinoRepository : IRepository<DestinoEntity>
{
    Task<IEnumerable<DestinoEntity>> ListarPorTipo(int idTipo);

    Task<DestinoEntity?> BuscarComActividades(int idDestino);
}
