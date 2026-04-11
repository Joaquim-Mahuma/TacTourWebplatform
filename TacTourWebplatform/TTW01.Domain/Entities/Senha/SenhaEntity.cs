using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;

namespace TacTourWebplatform.TTW01.Domain.Entities.Senha;

[Table("senha")]
public class SenhaEntity
{

    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("senha_hash")]
    public string SenhaHash { get; set; } = string.Empty;

    [Column("senha_salt")]
    public string SenhaSalt { get; set; } = string.Empty;

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    //*PROPRIEDADES NAVEGACIONAIS
    public UsuarioEntity Usuario { get; set; } = null!;

}
