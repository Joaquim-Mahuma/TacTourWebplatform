using System;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class DestinoRepository : BaseRepository<DestinoEntity>, IDestinoRepository
{
    public DestinoRepository(TacTourDbContext context)
        : base(context){}

    public async Task<IEnumerable<DestinoEntity>> ListarPorTipo(int idTipo)
    {
        return await context.TabelaDestino.Where(d => d.IdTipoDestino == idTipo).ToListAsync();
    }

    public async Task<DestinoEntity?> BuscarComActividades(int idDestino)
    {
        return await context.TabelaDestino
            .Include(d => d.Actividades)
            .FirstOrDefaultAsync(d => d.Id == idDestino);
    }
}
