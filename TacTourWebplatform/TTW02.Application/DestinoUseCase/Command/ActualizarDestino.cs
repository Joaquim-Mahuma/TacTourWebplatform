using System;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.Command;

public class ActualizarDestino(IDestinoRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarDestinoDTO dto)
    {
        var model = new DestinoEntity
        {
            Id = id,
            Destino = dto.DestinoName,
            IdTipoDestino = dto.TipoDestinoId 
        };

        return await repository.Actualizar(model);
    }
}
