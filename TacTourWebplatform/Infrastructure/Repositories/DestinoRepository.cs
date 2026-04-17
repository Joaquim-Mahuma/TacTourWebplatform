using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Domain.Entities;
using TacTourWebplatform.Domain.Interfaces;
using TacTourWebplatform.Infrastructure.Data;

namespace TacTourWebplatform.Infrastructure.Repositories;

public class DestinoRepository(TacTourDbContext context) : BaseRepository<Destino>(context), IDestinoRepository
{
    public async Task<IEnumerable<Destino>> ListarPorTipo(int idTipo)
    {
        return await Context.Destinos.Where(d => d.IdTipoDestino == idTipo).ToListAsync();
    }
}
