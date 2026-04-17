using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("pacote_incluido")]
public class PacoteIncluido
{
    [Column("id")]
    public int Id { get; set; }

    [Column("id_pacote")]
    public int IdPacote { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("ordem")]
    public int Ordem { get; set; }

    public Pacote? Pacote { get; set; }
}
