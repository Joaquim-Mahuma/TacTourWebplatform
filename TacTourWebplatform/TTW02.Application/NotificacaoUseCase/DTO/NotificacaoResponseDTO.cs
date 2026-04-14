namespace TacTourWebplatform.TTW02.Application.NotificacaoUseCase.DTO;

public class NotificacaoResponseDTO
{
    public int NotificacaoId { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public DateTime DataEnvio { get; set; }

    public int OrigemId { get; set; }

    public int DestinoId { get; set; }
}
