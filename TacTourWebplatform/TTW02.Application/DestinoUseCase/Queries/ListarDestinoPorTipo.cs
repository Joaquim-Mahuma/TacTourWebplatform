using System;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.Queries;

public class ListarDestinoPorTipo(IDestinoRepository repository)
{
    //* Recebe o texto do filtro como parâmetro
    public async Task<IEnumerable<ListarDestinoPorTipoDTO>> ListarDestinoPorTipoAsync(int id)
    {
        //* Chama o método específico do repository
        var lista = await repository.ListarPorTipo(id);

        //* Converte igual ao padrão base
        return lista.Select(x => new ListarDestinoPorTipoDTO
        {
            DestinoId = x.Id,
            DestinoName = x.Destino,
            TipoDestinoId = x.IdTipoDestino,
        }).ToList();
    }

}
