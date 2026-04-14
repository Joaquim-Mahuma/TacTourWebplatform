using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteNaoIncluido;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class PacoteNaoIncluidoRepository(TacTourDbContext context)
    : BaseRepository<PacoteNaoIncluidoEntity>(context), IPacoteNaoIncluidoRepository
{
    public async Task<IEnumerable<PacoteNaoIncluidoEntity>> ListarPorPacote(int idPacote)
    {
        return await this.context.TabelaPacoteNaoIncluidos
            .Where(x => x.IdPacote == idPacote)
            .OrderBy(x => x.Ordem)
            .ToListAsync();
    }
}
