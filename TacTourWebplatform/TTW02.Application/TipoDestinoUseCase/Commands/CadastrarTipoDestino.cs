using System;
using TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Commands;

public class CadastrarTipoDestino(ITipoDestinoRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarTipoDestinoDTO dto)
    {
        var model = new TipoDestinoEntity
        {
            TipoDestino = dto.TipoDestinoName
        };

        return await repository.Cadastrar(model);
    }
}