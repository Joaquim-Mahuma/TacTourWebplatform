using System;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Queries;

public class PesquisarTipoDestinoId(ITipoDestinoRepository repository)
{
    public async Task<TipoDestinoResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model == null) return null;

        return new TipoDestinoResponseDTO
        {
            TipoDestinoId = model.Id,
            TipoDestinoNome = model.TipoDestino
        };
    }
}
