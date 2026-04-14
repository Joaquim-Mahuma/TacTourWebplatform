using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ActividadeUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ActividadeUseCase.Queries;

public class PesquisarActividadeId(IActividadeRepository repository)
{
    public async Task<ActividadeResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new ActividadeResponseDTO
        {
            ActividadeId = model.Id,
            ActividadeNome = model.NomeActividade,
            DestinoId = model.IdDestino
        };
    }
}
