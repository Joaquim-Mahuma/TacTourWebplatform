using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.Itinerario;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class ItinerarioRepository(TacTourDbContext context)
    : BaseRepository<ItinerarioEntity>(context), IItinerarioRepository
{
    public async Task<IEnumerable<ItinerarioEntity>> ListarPorPacote(int idPacote)
    {
        return await this.context.TabelaItinerario
            .Where(x => x.IdPacote == idPacote)
            .OrderBy(x => x.Ordem)
            .ToListAsync();
    }
}
