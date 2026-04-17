using TacTourWebplatform.Domain.Entities;

namespace TacTourWebplatform.Domain.Interfaces;

public interface IReservaRepository : IRepository<Reserva>
{
    Task<IEnumerable<Reserva>> ListarReservaPorUsuario(int idUsuario);

    Task<IEnumerable<Reserva>> ListarReservaPorPacote(int idPacote);

    Task<IEnumerable<Reserva>> ListarReservaPorEstado(string estado);

    Task<IEnumerable<Reserva>> ListarReservaPorTipo(string tipo);

    Task<IEnumerable<Reserva>> ListarComDetalhesAsync();

    Task<Reserva?> ObterComDetalhesAsync(int id);

    Task<Reserva?> ObterParaEdicaoAsync(int id);

    Task GuardarAlteracoesAsync(Reserva reserva);
}
