using System;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.Queries;

public class ListarDestinoPorTipo(IDestinoRepository repository)
{
    //* Recebe o id do filtro(tipo de destino) como parâmetro
    public async Task<IEnumerable<ListarDestinoDTO>> ListarDestinoPorTipoAsync(int id)
    {
        //* Chama o método específico do repository
        var lista = await repository.ListarPorTipo(id);

        //* Converte igual ao padrão base
        return lista.Select(x => new ListarDestinoDTO
        {
            DestinoId = x.Id,
            DestinoName = x.Destino,
            TipoDestinoId = x.IdTipoDestino
        }).ToList();
    }

}
