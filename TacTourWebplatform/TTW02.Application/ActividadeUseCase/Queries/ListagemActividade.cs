using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ActividadeUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ActividadeUseCase.Queries;

public class ListagemActividade(IActividadeRepository repository)
{
    public async Task<List<ActividadeResponseDTO>> ListagemAsync()
    {
        var models = await repository.Listagem();

        return models.Select(model => new ActividadeResponseDTO
        {
            ActividadeId = model.Id,
            ActividadeNome = model.NomeActividade,
            DestinoId = model.IdDestino
        }).ToList();
    }
}
