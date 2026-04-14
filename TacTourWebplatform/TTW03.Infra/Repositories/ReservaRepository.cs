using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.Reserva;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class ReservaRepository(TacTourDbContext context)
    : BaseRepository<ReservaEntity>(context), IReservaRepository
{
    public async Task<IEnumerable<ReservaEntity>> ListarReservaPorUsuario(int idUsuario)
    {
        return await this.context.TabelaReserva
            .Where(x => x.IdUsuario == idUsuario)
            .ToListAsync();
    }

    public async Task<IEnumerable<ReservaEntity>> ListarReservaPorPacote(int idPacote)
    {
        return await this.context.TabelaReserva
            .Where(x => x.IdPacote == idPacote)
            .ToListAsync();
    }

    public async Task<IEnumerable<ReservaEntity>> ListarReservaPorEstado(string estado)
    {
        if (string.IsNullOrWhiteSpace(estado))
        {
            return [];
        }

        var filtro = estado.Trim().ToLower();

        return await this.context.TabelaReserva
            .Where(x => x.EstadoReserva.ToLower() == filtro)
            .ToListAsync();
    }

    public async Task<IEnumerable<ReservaEntity>> ListarReservaPorTipo(string tipo)
    {
        if (string.IsNullOrWhiteSpace(tipo))
        {
            return [];
        }

        var filtro = tipo.Trim().ToLower();

        return await this.context.TabelaReserva
            .Where(x => x.TipoReserva.ToLower() == filtro)
            .ToListAsync();
    }
}
