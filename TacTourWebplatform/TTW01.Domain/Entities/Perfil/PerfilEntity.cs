using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;



namespace TacTourWebplatform.TTW01.Domain.Entities.Perfil;

[Table("perfil")]


public class PerfilEntity
{

    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("tipo_perfil")]
    public string TipoPerfil { get; set; } = string.Empty;



    //*PROPRIEDADES NAVEGACIONAIS
    public ICollection<UsuarioEntity> Usuarios { get; set; } = [];
}
