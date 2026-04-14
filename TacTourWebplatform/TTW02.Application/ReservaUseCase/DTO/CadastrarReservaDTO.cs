using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.ReservaUseCase.DTO;

public class CadastrarReservaDTO
{
    [Required(ErrorMessage = "O tipo da reserva e obrigatorio")]
    public string TipoReserva { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data da solicitacao e obrigatoria")]
    public DateTime DataSolicitacao { get; set; }

    [Required(ErrorMessage = "A quantidade de pessoas e obrigatoria")]
    public int QuantidadePessoas { get; set; }

    [Required(ErrorMessage = "O preco total e obrigatorio")]
    public decimal PrecoTotal { get; set; }

    [Required(ErrorMessage = "O estado da reserva e obrigatorio")]
    public string EstadoReserva { get; set; } = string.Empty;

    [Required(ErrorMessage = "O usuario da reserva e obrigatorio")]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "O pacote da reserva e obrigatorio")]
    public int PacoteId { get; set; }
}
