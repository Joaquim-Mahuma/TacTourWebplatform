using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("actividade")]
public class Actividade
{
    [Column("id")]
    public int Id { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("id_destino")]
    public int IdDestino { get; set; }

    public Destino? Destino { get; set; }
}
