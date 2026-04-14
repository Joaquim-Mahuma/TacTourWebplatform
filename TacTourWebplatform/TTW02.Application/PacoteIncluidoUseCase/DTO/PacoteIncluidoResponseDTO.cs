namespace TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.DTO;

public class PacoteIncluidoResponseDTO
{
    public int PacoteIncluidoId { get; set; }

    public int PacoteId { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public int Ordem { get; set; }
}
