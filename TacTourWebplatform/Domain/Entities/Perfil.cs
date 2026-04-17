using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("perfil")]
public class Perfil
{
    [Column("id")]
    public int Id { get; set; }

    [Column("tipo_perfil")]
    public string TipoPerfil { get; set; } = string.Empty;

    public ICollection<Usuario> Usuarios { get; set; } = [];
}
