using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.DTO;

public class ActualizarPacoteTuristicoDTO
{
    [Required(ErrorMessage = "O titulo do pacote e obrigatorio")]
    public string TituloPacote { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descricao do pacote e obrigatoria")]
    public string DescricaoPacote { get; set; } = string.Empty;

    [Required(ErrorMessage = "O preco base e obrigatorio")]
    public decimal PrecoBase { get; set; }

    [Required(ErrorMessage = "A data de inicio e obrigatoria")]
    public DateOnly DataInicio { get; set; }

    [Required(ErrorMessage = "A data de fim e obrigatoria")]
    public DateOnly DataFim { get; set; }

    [Required(ErrorMessage = "A duracao e obrigatoria")]
    public int Duracao { get; set; }

    [Required(ErrorMessage = "O ponto de encontro e obrigatorio")]
    public string PontoEncontro { get; set; } = string.Empty;

    [Required(ErrorMessage = "O ponto de largada e obrigatorio")]
    public string PontoLargada { get; set; } = string.Empty;

    [Required(ErrorMessage = "O estado do pacote e obrigatorio")]
    public string EstadoPacote { get; set; } = string.Empty;

    [Required(ErrorMessage = "O operador do pacote e obrigatorio")]
    public int OperadorId { get; set; }
}
