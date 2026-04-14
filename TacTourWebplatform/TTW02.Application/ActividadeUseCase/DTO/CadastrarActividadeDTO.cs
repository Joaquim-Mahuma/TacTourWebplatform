using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.ActividadeUseCase.DTO;

public class CadastrarActividadeDTO
{
    [Required(ErrorMessage = "O nome da actividade e obrigatorio")]
    public string ActividadeNome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O destino da actividade e obrigatorio")]
    public int DestinoId { get; set; }
}
