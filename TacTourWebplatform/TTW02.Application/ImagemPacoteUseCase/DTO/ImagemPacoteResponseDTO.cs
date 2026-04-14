namespace TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.DTO;

public class ImagemPacoteResponseDTO
{
    public int ImagemPacoteId { get; set; }

    public string UrlImage { get; set; } = string.Empty;

    public string DescricaoImage { get; set; } = string.Empty;

    public int PacoteId { get; set; }
}
