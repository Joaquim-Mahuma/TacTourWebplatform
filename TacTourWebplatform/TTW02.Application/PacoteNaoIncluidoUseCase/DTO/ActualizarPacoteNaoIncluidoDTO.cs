using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.DTO;

public class ActualizarPacoteNaoIncluidoDTO
{
    [Required(ErrorMessage = "O pacote e obrigatorio")]
    public int PacoteId { get; set; }

    [Required(ErrorMessage = "A descricao e obrigatoria")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "A ordem e obrigatoria")]
    public int Ordem { get; set; }
}
