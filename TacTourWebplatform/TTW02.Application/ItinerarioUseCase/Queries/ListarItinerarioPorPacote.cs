using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ItinerarioUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ItinerarioUseCase.Queries;

public class ListarItinerarioPorPacote(IItinerarioRepository repository)
{
    public async Task<List<ItinerarioResponseDTO>> ListarPorPacoteAsync(int pacoteId)
    {
        var models = await repository.ListarPorPacote(pacoteId);

        return models.Select(model => new ItinerarioResponseDTO
        {
            ItinerarioId = model.Id,
            Ordem = model.Ordem,
            PacoteId = model.IdPacote,
            DestinoId = model.IdDestino
        }).ToList();
    }
}
