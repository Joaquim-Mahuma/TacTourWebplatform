using System;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Queries;

public class ListagemTipoDestino(ITipoDestinoRepository repository)
{
    public async Task<List<TipoDestinoResponseDTO>> ListagemAsync()
    {

        var models = await repository.Listagem();

        return models.Select(model => new TipoDestinoResponseDTO
        {
            TipoDestinoId = model.Id,
            TipoDestinoNome = model.TipoDestino
        }).ToList();
    }
}
