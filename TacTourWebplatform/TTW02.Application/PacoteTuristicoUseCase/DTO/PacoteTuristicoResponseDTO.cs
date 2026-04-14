namespace TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.DTO;

public class PacoteTuristicoResponseDTO
{
    public int PacoteTuristicoId { get; set; }

    public string TituloPacote { get; set; } = string.Empty;

    public string DescricaoPacote { get; set; } = string.Empty;

    public decimal PrecoBase { get; set; }

    public DateOnly DataInicio { get; set; }

    public DateOnly DataFim { get; set; }

    public int Duracao { get; set; }

    public string PontoEncontro { get; set; } = string.Empty;

    public string PontoLargada { get; set; } = string.Empty;

    public string EstadoPacote { get; set; } = string.Empty;

    public int OperadorId { get; set; }
}
