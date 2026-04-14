using TacTourWebplatform.TTW01.Domain.Entities.Itinerario;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ItinerarioUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ItinerarioUseCase.Command;

public class ActualizarItinerario(IItinerarioRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarItinerarioDTO dto)
    {
        var model = new ItinerarioEntity
        {
            Id = id,
            Ordem = dto.Ordem,
            IdPacote = dto.PacoteId,
            IdDestino = dto.DestinoId
        };

        return await repository.Actualizar(model);
    }
}
