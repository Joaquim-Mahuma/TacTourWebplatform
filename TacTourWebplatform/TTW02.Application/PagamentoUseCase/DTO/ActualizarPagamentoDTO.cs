using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.PagamentoUseCase.DTO;

public class ActualizarPagamentoDTO
{
    [Required(ErrorMessage = "O comprovativo e obrigatorio")]
    public decimal ComprovativoUrl { get; set; }

    [Required(ErrorMessage = "A data de pagamento e obrigatoria")]
    public DateTime DataPagamento { get; set; }

    [Required(ErrorMessage = "A data de confirmacao e obrigatoria")]
    public DateTime DataConfirmacao { get; set; }

    [Required(ErrorMessage = "O estado do pagamento e obrigatorio")]
    public string EstadoPagamento { get; set; } = string.Empty;

    [Required(ErrorMessage = "A reserva do pagamento e obrigatoria")]
    public int ReservaId { get; set; }
}
