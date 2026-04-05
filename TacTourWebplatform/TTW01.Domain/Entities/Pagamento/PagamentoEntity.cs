using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Reserva;

namespace TacTourWebplatform.TTW01.Domain.Entities.Pagamento;


[Table("pagamento")]
public class PagamentoEntity
{


    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("comprovativo_url")]
    public decimal ComprovativoUrl { get; set; }

    [Column("data_pagamento")]
    public DateTime DataPagamento { get; set; }

    [Column("data_confirmacao")]
    public DateTime DataConfirmacao { get; set; }

    [Column("estado_pagamento")]
    public string EstadoPagamento { get; set; }

    [Column("id_reserva")]
    public int IdReserva { get; set; }



    //*PROPRIEDADES NAVEGACIONAIS
    public ReservaEntity Reserva { get; set; }

}
