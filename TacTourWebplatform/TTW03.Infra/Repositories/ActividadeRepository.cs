using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.Actividade;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class ActividadeRepository(TacTourDbContext context)
    : BaseRepository<ActividadeEntity>(context), IActividadeRepository
{
    public async Task<IEnumerable<ActividadeEntity>> ListarPorDestino(int idDestino)
    {
        return await this.context.TabelaActividade
            .Where(x => x.IdDestino == idDestino)
            .ToListAsync();
    }
}
