using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.ItinerarioUseCase.DTO;

public class CadastrarItinerarioDTO
{
    [Required(ErrorMessage = "A ordem do itinerario e obrigatoria")]
    public int Ordem { get; set; }

    [Required(ErrorMessage = "O pacote do itinerario e obrigatorio")]
    public int PacoteId { get; set; }

    [Required(ErrorMessage = "O destino do itinerario e obrigatorio")]
    public int DestinoId { get; set; }
}
