using TacTourWebplatform.TTW01.Domain.Entities.Actividade;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ActividadeUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ActividadeUseCase.Command;

public class ActualizarActividade(IActividadeRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarActividadeDTO dto)
    {
        var model = new ActividadeEntity
        {
            Id = id,
            NomeActividade = dto.ActividadeNome,
            IdDestino = dto.DestinoId
        };

        return await repository.Actualizar(model);
    }
}
