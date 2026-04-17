using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Domain.Entities;
using TacTourWebplatform.Domain.Interfaces;
using TacTourWebplatform.Infrastructure.Data;

namespace TacTourWebplatform.Infrastructure.Repositories;

public class TipoDestinoRepository(TacTourDbContext context) : BaseRepository<TipoDestino>(context), ITipoDestinoRepository
{
    public async Task<TipoDestino?> PesquisarPorTexto(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return null;

        var termo = texto.Trim().ToLower();
        return await Context.TiposDestino
            .FirstOrDefaultAsync(t => t.Nome.ToLower().Contains(termo));
    }
}
