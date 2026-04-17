using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("senha")]
public class Senha
{
    [Column("id")]
    public int Id { get; set; }

    [Column("senha_hash")]
    public string SenhaHash { get; set; } = string.Empty;

    [Column("senha_salt")]
    public string SenhaSalt { get; set; } = string.Empty;

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    public Usuario Usuario { get; set; } = null!;
}
