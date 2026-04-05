using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;
using TacTourWebplatform.TTW01.Domain.Entities.Pagamento;
using TacTourWebplatform.TTW01.Domain.Entities.ReservaDestino;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;

namespace TacTourWebplatform.TTW01.Domain.Entities.Reserva;

[Table("reserva")]
public class ReservaEntity
{


    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("tipo_reserva")]
    public string TipoReserva { get; set; }

    [Column("data_solicitacao")]
    public DateTime DataSolicitacao { get; set; }

    [Column("quantidade_pessoas")]
    public int QuantidadePessoas { get; set; }

    [Column("preco_total")]
    public decimal PrecoTotal { get; set; }

    [Column("estado_reserva")]
    public string EstadoReserva { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_pacote")]
    public int IdPacote { get; set; }


    //*PROPRIEDADES NAVEGACIONAIS
    public UsuarioEntity Usuario { get; set; }

    public PagamentoEntity Pagamento { get; set; }

    public PacoteEntity Pacote { get; set; }

    public ICollection<ReservaDestinoEntity> ReservaDestinos { get; set; } = [];

}