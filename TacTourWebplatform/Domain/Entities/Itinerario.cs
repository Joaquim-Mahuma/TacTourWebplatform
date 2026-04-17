using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("itinerario")]
public class Itinerario
{
    [Column("id")]
    public int Id { get; set; }

    [Column("ordem")]
    public int Ordem { get; set; }

    [Column("id_pacote")]
    public int IdPacote { get; set; }

    [Column("id_destino")]
    public int IdDestino { get; set; }

    public Pacote? Pacote { get; set; }

    public Destino? Destino { get; set; }
}
