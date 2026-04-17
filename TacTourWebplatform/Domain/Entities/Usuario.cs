using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("usuario")]
public class Usuario
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("telefone")]
    public string Telefone { get; set; } = string.Empty;

    [Column("data_nascimento")]
    public DateTime DataNascimento { get; set; }

    [Column("foto")]
    public string Foto { get; set; } = string.Empty;

    [Column("nacionalidade")]
    public string Nacionalidade { get; set; } = string.Empty;

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; }

    [Column("ultimo_login")]
    public DateTime UltimoLogin { get; set; }

    [Column("deletado_em")]
    public DateTime DeletadoEm { get; set; }

    [Column("id_perfil")]
    public int IdPerfil { get; set; }

    public virtual Perfil? Perfil { get; set; }

    public virtual Senha? Senha { get; set; }

    public ICollection<Pacote> Pacotes { get; set; } = [];

    public ICollection<Notificacao> NotificacoesEnviadas { get; set; } = [];

    public ICollection<Notificacao> NotificacoesRecebidas { get; set; } = [];

    public ICollection<Reserva> Reservas { get; set; } = [];
}
