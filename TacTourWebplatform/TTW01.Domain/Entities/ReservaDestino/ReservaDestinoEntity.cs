using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;
using TacTourWebplatform.TTW01.Domain.Entities.Reserva;

namespace TacTourWebplatform.TTW01.Domain.Entities.ReservaDestino;


[Table("reserva_destino")]
public class ReservaDestinoEntity
{


    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("ordem")]
    public int OrdemDestino { get; set; }

    [Column("data_inicio")]
    public DateOnly DataInicio { get; set; }

    [Column("data_fim")]
    public DateOnly DataFim { get; set; }

    [Column("id_reserva")]
    public int IdReserva { get; set; }

    [Column("id_destino")]
    public int IdDestino { get; set; }


    //*PROPRIEDADES NAVEGACIONAIS
    public ReservaEntity Reserva { get; set; }

    public DestinoEntity Destino { get; set; }


}
