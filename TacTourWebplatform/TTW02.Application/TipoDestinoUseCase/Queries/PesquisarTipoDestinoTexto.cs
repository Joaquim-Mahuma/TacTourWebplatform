using System;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Queries;

public class PesquisarTipoDestinoTexto(ITipoDestinoRepository repository)
{
    public async Task<TipoDestinoResponseDTO?> PesquisarTextoAsync(string texto)
    {
        var model = await repository.PesquisarPorTexto(texto);
        if (model == null) return null;

        return new TipoDestinoResponseDTO
        {
            TipoDestinoId = model.Id,
            TipoDestinoNome = model.TipoDestino
        };


    }
}
