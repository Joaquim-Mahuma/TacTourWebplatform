using System;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.Command;

public class CadastrarDestino(IDestinoRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarDestinoDTO dto)
    {
        var model = new DestinoEntity
        {
            Destino = dto.DestinoName,
            IdTipoDestino = dto.TipoDestinoId
        };

        return await repository.Cadastrar(model);
    }
}
