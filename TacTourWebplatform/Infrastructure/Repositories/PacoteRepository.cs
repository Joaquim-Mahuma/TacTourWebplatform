using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Domain.Entities;
using TacTourWebplatform.Domain.Interfaces;
using TacTourWebplatform.Infrastructure.Data;

namespace TacTourWebplatform.Infrastructure.Repositories;

public class PacoteRepository(TacTourDbContext context) : BaseRepository<Pacote>(context), IPacoteRepository
{
    public async Task<IEnumerable<Pacote>> ListarPacotesActivos()
    {
        return await Context.Pacotes
            .Where(p => p.Estado.ToLower() == "ativo")
            .ToListAsync();
    }

    public async Task<IEnumerable<Pacote>> ListarPacotesPorDestino(int idDestino)
    {
        return await Context.Pacotes
            .Where(p => p.Itinerarios.Any(i => i.IdDestino == idDestino))
            .ToListAsync();
    }

    public async Task<IEnumerable<Pacote>> ListarPacotesPorNome(string nome)
    {
        var n = nome.Trim().ToLower();
        return await Context.Pacotes
            .Where(p => p.Titulo.ToLower().Contains(n))
            .ToListAsync();
    }

    public async Task<IEnumerable<Pacote>> ListarPacotesPorOperador(int idOperador)
    {
        return await Context.Pacotes.Where(p => p.IdOperador == idOperador).ToListAsync();
    }

    public async Task<IEnumerable<Pacote>> ListarComImagensAsync()
    {
        return await Context.Pacotes
            .AsNoTracking()
            .Include(p => p.Imagens.OrderBy(i => i.Id))
            .OrderByDescending(p => p.Id)
            .ToListAsync();
    }

    public async Task<Pacote?> ObterComRelacoesAsync(int id)
    {
        return await Context.Pacotes
            .Include(p => p.Imagens)
            .Include(p => p.ItensIncluidos)
            .Include(p => p.ItensNaoIncluidos)
            .Include(p => p.InfoImportantes)
            .Include(p => p.Itinerarios).ThenInclude(i => i.Destino)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AdicionarImagemAsync(int idPacote, string url, string descricao)
    {
        await Context.ImagensPacote.AddAsync(new ImagemPacote
        {
            IdPacote = idPacote,
            UrlImagem = url,
            Descricao = descricao,
        });
        await Context.SaveChangesAsync();
    }
}
