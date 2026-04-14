using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.PerfilUseCase.DTO;

public class CadastrarPerfilDTO
{
    [Required(ErrorMessage = "O tipo de perfil e obrigatorio")]
    public string TipoPerfil { get; set; } = string.Empty;
}
