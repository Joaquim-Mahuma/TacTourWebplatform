using System;
using TacTourWebplatform.TTW01.Domain.Entities.Reserva;

namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IReservaRepository : IRepository<ReservaEntity>
{
    Task<IEnumerable<ReservaEntity>> ListarReservaPorUsuario(int idUsuario);
    Task<IEnumerable<ReservaEntity>> ListarReservaPorPacote(int idPacote);
    Task<IEnumerable<ReservaEntity>> ListarReservaPorEstado(string estado);
    Task<IEnumerable<ReservaEntity>> ListarReservaPorTipo(string tipo);
}
