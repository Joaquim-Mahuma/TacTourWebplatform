using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ItinerarioUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ItinerarioUseCase.Queries;

public class PesquisarItinerarioId(IItinerarioRepository repository)
{
    public async Task<ItinerarioResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new ItinerarioResponseDTO
        {
            ItinerarioId = model.Id,
            Ordem = model.Ordem,
            PacoteId = model.IdPacote,
            DestinoId = model.IdDestino
        };
    }
}
