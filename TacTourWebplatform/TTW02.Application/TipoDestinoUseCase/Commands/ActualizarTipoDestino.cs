using System;
using TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Commands;

public class ActualizarTipoDestino(ITipoDestinoRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarTipoDestinoDTO dto)
    {
        var model = new TipoDestinoEntity
        {
            Id = id,
            TipoDestino = dto.TipoDestinoName
        };
        return await repository.Actualizar(model);
    }
}