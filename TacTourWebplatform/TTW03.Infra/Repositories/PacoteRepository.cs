using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class PacoteRepository(TacTourDbContext context)
    : BaseRepository<PacoteEntity>(context), IPacoteRepository
{
    public async Task<IEnumerable<PacoteEntity>> ListarPacotesActivos()
    {
        return await this.context.TabelaPacoteTuristico
            .Where(x => x.EstadoPacote.ToLower() == "activo" || x.EstadoPacote.ToLower() == "ativo")
            .ToListAsync();
    }

    public async Task<IEnumerable<PacoteEntity>> ListarPacotesPorDestino(int idDestino)
    {
        return await this.context.TabelaPacoteTuristico
            .Where(x => this.context.TabelaItinerario.Any(i => i.IdPacote == x.Id && i.IdDestino == idDestino))
            .ToListAsync();
    }

    public async Task<IEnumerable<PacoteEntity>> ListarPacotesPorNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            return [];
        }

        var termo = nome.Trim().ToLower();

        return await this.context.TabelaPacoteTuristico
            .Where(x => x.TituloPacote.ToLower().Contains(termo))
            .ToListAsync();
    }

    public async Task<IEnumerable<PacoteEntity>> ListarPacotesPorOperador(int idOperador)
    {
        return await this.context.TabelaPacoteTuristico
            .Where(x => x.IdOperador == idOperador)
            .ToListAsync();
    }
}
