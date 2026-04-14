using System;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.Queries;

public class ListagemDestino(IDestinoRepository repository)
{
    public async Task<List<ListarDestinoDTO>> ListagemAsync()
    {
        var models = await repository.Listagem();

        return models.Select(model => new ListarDestinoDTO {
            DestinoId = model.Id,
            DestinoName = model.Destino,
            TipoDestinoId = model.IdTipoDestino
        }).ToList();
    }
}
