using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.NotificacaoUseCase.DTO;

public class ActualizarNotificacaoDTO
{
    [Required(ErrorMessage = "O titulo da notificacao e obrigatorio")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descricao da notificacao e obrigatoria")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de envio e obrigatoria")]
    public DateTime DataEnvio { get; set; }

    [Required(ErrorMessage = "O utilizador de origem e obrigatorio")]
    public int OrigemId { get; set; }

    [Required(ErrorMessage = "O utilizador de destino e obrigatorio")]
    public int DestinoId { get; set; }
}
