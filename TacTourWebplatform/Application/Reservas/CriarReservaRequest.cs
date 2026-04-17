using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.Application.Reservas;

public class CriarReservaRequest
{
    [Required]
    public int IdPacote { get; set; }

    [Required]
    public int IdUsuario { get; set; }

    [Range(1, 500)]
    public int QuantidadePessoas { get; set; } = 1;

    public string TipoReserva { get; set; } = "normal";
}
