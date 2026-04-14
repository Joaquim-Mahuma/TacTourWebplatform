namespace TacTourWebplatform.TTW02.Application.PagamentoUseCase.DTO;

public class PagamentoResponseDTO
{
    public int PagamentoId { get; set; }

    public decimal ComprovativoUrl { get; set; }

    public DateTime DataPagamento { get; set; }

    public DateTime DataConfirmacao { get; set; }

    public string EstadoPagamento { get; set; } = string.Empty;

    public int ReservaId { get; set; }
}
