using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteIncluido;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class PacoteIncluidoRepository(TacTourDbContext context)
    : BaseRepository<PacoteIncluidoEntity>(context), IPacoteIncluidoRepository
{
    public async Task<IEnumerable<PacoteIncluidoEntity>> ListarPorPacote(int idPacote)
    {
        return await this.context.TabelaPacoteIncluidos
            .Where(x => x.IdPacote == idPacote)
            .OrderBy(x => x.Ordem)
            .ToListAsync();
    }
}
