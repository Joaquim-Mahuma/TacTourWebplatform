namespace TacTourWebplatform.Application.Reservas;

public class ReservaListagemResponse
{
    public int Id { get; set; }

    public int IdPacote { get; set; }

    public string TituloPacote { get; set; } = string.Empty;

    public string NomeCliente { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string DataSolicitacao { get; set; } = string.Empty;

    public int Pessoas { get; set; }

    public decimal PrecoTotal { get; set; }

    public string EstadoReserva { get; set; } = string.Empty;

    public bool ComprovativoEnviado { get; set; }
}
