using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("notificacao")]
public class Notificacao
{
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    public string Titulo { get; set; } = string.Empty;

    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("data_envio")]
    public DateTime DataEnvio { get; set; }

    [Column("id_origem")]
    public int IdOrigem { get; set; }

    [Column("id_destino")]
    public int IdDestino { get; set; }

    public Usuario? UsuarioOrigem { get; set; }

    public Usuario? UsuarioDestino { get; set; }
}
