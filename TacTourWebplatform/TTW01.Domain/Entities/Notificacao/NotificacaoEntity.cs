using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;

namespace TacTourWebplatform.TTW01.Domain.Entities.Notificacao;


[Table("notificacao")]
public class NotificacaoEntity
{


    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    public string Titulo { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; }

    [Column("data_envio")]
    public DateTime DataEnvio { get; set; }

    [Column("id_origem")]
    public int IdOrigem { get; set; }

    [Column("id_destino")]
    public int IdDestino { get; set; }



    //*PROPRIEDADES NAVEGACIONAIS
    public UsuarioEntity UsuarioOrigem { get; set; }

    public UsuarioEntity UsuarioDestino { get; set; }
}
