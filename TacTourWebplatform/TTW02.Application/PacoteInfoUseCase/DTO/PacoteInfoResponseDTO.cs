namespace TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.DTO;

public class PacoteInfoResponseDTO
{
    public int PacoteInfoId { get; set; }

    public int PacoteId { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public int Ordem { get; set; }
}
