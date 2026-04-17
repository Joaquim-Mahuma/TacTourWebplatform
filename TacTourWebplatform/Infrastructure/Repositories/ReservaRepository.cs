using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Domain.Entities;
using TacTourWebplatform.Domain.Interfaces;
using TacTourWebplatform.Infrastructure.Data;

namespace TacTourWebplatform.Infrastructure.Repositories;

public class ReservaRepository(TacTourDbContext context) : BaseRepository<Reserva>(context), IReservaRepository
{
    public async Task<IEnumerable<Reserva>> ListarReservaPorUsuario(int idUsuario)
    {
        return await Context.Reservas.Where(r => r.IdUsuario == idUsuario).ToListAsync();
    }

    public async Task<IEnumerable<Reserva>> ListarReservaPorPacote(int idPacote)
    {
        return await Context.Reservas.Where(r => r.IdPacote == idPacote).ToListAsync();
    }

    public async Task<IEnumerable<Reserva>> ListarReservaPorEstado(string estado)
    {
        var e = estado.Trim().ToLower();
        return await Context.Reservas.Where(r => r.EstadoReserva.ToLower() == e).ToListAsync();
    }

    public async Task<IEnumerable<Reserva>> ListarReservaPorTipo(string tipo)
    {
        var t = tipo.Trim().ToLower();
        return await Context.Reservas.Where(r => r.TipoReserva.ToLower() == t).ToListAsync();
    }

    public async Task<IEnumerable<Reserva>> ListarComDetalhesAsync()
    {
        return await Context.Reservas
            .AsNoTracking()
            .Include(r => r.Pacote)
            .Include(r => r.Usuario)
            .Include(r => r.Pagamento)
            .OrderByDescending(r => r.DataSolicitacao)
            .ToListAsync();
    }

    public async Task<Reserva?> ObterComDetalhesAsync(int id)
    {
        return await Context.Reservas
            .Include(r => r.Pacote)
            .Include(r => r.Usuario)
            .Include(r => r.Pagamento)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Reserva?> ObterParaEdicaoAsync(int id)
    {
        return await Context.Reservas
            .Include(r => r.Pacote)
            .Include(r => r.Usuario)
            .Include(r => r.Pagamento)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task GuardarAlteracoesAsync(Reserva reserva)
    {
        _ = reserva;
        await Context.SaveChangesAsync();
    }
}
