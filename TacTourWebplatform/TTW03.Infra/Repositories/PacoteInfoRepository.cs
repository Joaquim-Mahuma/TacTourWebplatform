using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteInfo;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class PacoteInfoRepository(TacTourDbContext context)
    : BaseRepository<PacoteInfoEntity>(context), IPacoteInfoRepository
{
    public async Task<IEnumerable<PacoteInfoEntity>> ListarPorPacote(int idPacote)
    {
        return await this.context.TabelaPacoteInfo
            .Where(x => x.IdPacote == idPacote)
            .OrderBy(x => x.Ordem)
            .ToListAsync();
    }
}
