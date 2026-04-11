using System;
using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class TipoDestinoRepository : BaseRepository<TipoDestinoEntity>, ITipoDestinoRepository
{

    //* CONSTRUTOR (TODO MÉTODO TEM)
    public TipoDestinoRepository(TacTourDbContext context)
        : base(context)
    {
    }

    //* MÉTODOS ESPECIFICOS DESTA ENTIDADE
    public async Task<TipoDestinoEntity?> PesquisarPorTexto(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return null;

        // Trim e ToLower para pesquisa mais amigável
        string termoPesquisa = texto.Trim().ToLower();

        return await context.TabelaTipoDestino
        .FirstOrDefaultAsync(td => td.TipoDestino.ToLower().Contains(termoPesquisa));
    }
}
