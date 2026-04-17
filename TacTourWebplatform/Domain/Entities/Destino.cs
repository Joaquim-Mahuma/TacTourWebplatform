using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("destino")]
public class Destino
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Column("id_tipo")]
    public int IdTipoDestino { get; set; }

    public ICollection<Itinerario> Itinerarios { get; set; } = [];

    public ICollection<Actividade> Actividades { get; set; } = [];

    public TipoDestino? TipoDestino { get; set; }
}
