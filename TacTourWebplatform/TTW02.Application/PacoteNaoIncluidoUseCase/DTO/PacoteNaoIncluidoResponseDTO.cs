namespace TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.DTO;

public class PacoteNaoIncluidoResponseDTO
{
    public int PacoteNaoIncluidoId { get; set; }

    public int PacoteId { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public int Ordem { get; set; }
}
