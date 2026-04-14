namespace TacTourWebplatform.TTW02.Application.ReservaUseCase.DTO;

public class ReservaResponseDTO
{
    public int ReservaId { get; set; }

    public string TipoReserva { get; set; } = string.Empty;

    public DateTime DataSolicitacao { get; set; }

    public int QuantidadePessoas { get; set; }

    public decimal PrecoTotal { get; set; }

    public string EstadoReserva { get; set; } = string.Empty;

    public int UsuarioId { get; set; }

    public int PacoteId { get; set; }
}
