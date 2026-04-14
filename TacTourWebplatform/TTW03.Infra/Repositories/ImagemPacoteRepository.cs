using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.ImagemPacote;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class ImagemPacoteRepository(TacTourDbContext context)
    : BaseRepository<ImagemPacoteEntity>(context), IImagemPacoteRepository
{
    public async Task<IEnumerable<ImagemPacoteEntity>> ListarPorPacote(int idPacote)
    {
        return await this.context.TabelaImagemPacote
            .Where(x => x.IdPacote == idPacote)
            .ToListAsync();
    }
}
