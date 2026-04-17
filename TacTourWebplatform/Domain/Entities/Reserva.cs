using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("reserva")]
public class Reserva
{
    [Column("id")]
    public int Id { get; set; }

    [Column("tipo_reserva")]
    public string TipoReserva { get; set; } = string.Empty;

    [Column("data_solicitacao")]
    public DateTime DataSolicitacao { get; set; }

    [Column("quantidade_pessoas")]
    public int QuantidadePessoas { get; set; }

    [Column("preco_total")]
    public decimal PrecoTotal { get; set; }

    [Column("estado_reserva")]
    public string EstadoReserva { get; set; } = string.Empty;

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_pacote")]
    public int IdPacote { get; set; }

    public Usuario? Usuario { get; set; }

    public Pagamento? Pagamento { get; set; }

    public Pacote? Pacote { get; set; }
}
