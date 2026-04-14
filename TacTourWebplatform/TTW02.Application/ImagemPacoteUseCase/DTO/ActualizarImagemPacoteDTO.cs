using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.DTO;

public class ActualizarImagemPacoteDTO
{
    [Required(ErrorMessage = "A url da imagem e obrigatoria")]
    public string UrlImage { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descricao da imagem e obrigatoria")]
    public string DescricaoImage { get; set; } = string.Empty;

    [Required(ErrorMessage = "O pacote da imagem e obrigatorio")]
    public int PacoteId { get; set; }
}
