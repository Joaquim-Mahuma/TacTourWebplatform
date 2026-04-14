using TacTourWebplatform.TTW01.Domain.Entities.Itinerario;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ItinerarioUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ItinerarioUseCase.Command;

public class CadastrarItinerario(IItinerarioRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarItinerarioDTO dto)
    {
        var model = new ItinerarioEntity
        {
            Ordem = dto.Ordem,
            IdPacote = dto.PacoteId,
            IdDestino = dto.DestinoId
        };

        return await repository.Cadastrar(model);
    }
}
