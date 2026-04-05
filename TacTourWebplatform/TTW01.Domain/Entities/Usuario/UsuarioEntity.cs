using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Notificacao;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;
using TacTourWebplatform.TTW01.Domain.Entities.Perfil;
using TacTourWebplatform.TTW01.Domain.Entities.Reserva;
using TacTourWebplatform.TTW01.Domain.Entities.Senha;

namespace TacTourWebplatform.TTW01.Domain.Entities.Usuario;

[Table("usuario")]
public class UsuarioEntity
{



    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string NomeUser { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("telefone")]
    public string Telefone { get; set; }

    [Column("data_nascimento")]
    public DateTime DataNascimento { get; set; }

    [Column("foto")]
    public string FotoUser { get; set; }

    [Column("nacionalidade")]
    public string Nacionalidade { get; set; }

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; }

    [Column("ultimo_login")]
    public DateTime UltimoLogin { get; set; }

    [Column("deletado_em")]
    public DateTime DeletadoEm { get; set; }

    [Column("id_perfil")]
    public int IdPerfil { get; set; }


    //*PROPRIEDADES NAVEGACIONAIS
    public PerfilEntity Perfil { get; set; }

    public SenhaEntity Senha { get; set; }

    public ICollection<PacoteEntity> Pacotes { get; set; } = [];

    public ICollection<NotificacaoEntity> NotificacoesEnviadas { get; set; } = [];

    public ICollection<NotificacaoEntity> NotificacoesRecebidas { get; set; } = [];

    public ICollection<ReservaEntity> Reservas { get; set; } = [];







}
