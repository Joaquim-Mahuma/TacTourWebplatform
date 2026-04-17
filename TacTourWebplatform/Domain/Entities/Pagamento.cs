using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("pagamento")]
public class Pagamento
{
    [Column("id")]
    public int Id { get; set; }

    [Column("comprovativo_url")]
    public string ComprovativoUrl { get; set; } = string.Empty;

    [Column("data_pagamento")]
    public DateTime DataPagamento { get; set; }

    [Column("data_confirmacao")]
    public DateTime DataConfirmacao { get; set; }

    [Column("estado_pagamento")]
    public string EstadoPagamento { get; set; } = string.Empty;

    [Column("id_reserva")]
    public int IdReserva { get; set; }

    public Reserva? Reserva { get; set; }
}
