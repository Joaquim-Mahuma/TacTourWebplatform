using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;

namespace TacTourWebplatform.TTW01.Domain.Entities.Itinerario;


[Table("itinerario")]
public class ItinerarioEntity
{


    //*PROPRIEDADES NAVEGACIONAIS
    [Column("id")]
    public int Id { get; set; }

    [Column("ordem")]
    public int Ordem { get; set; }

    [Column("id_pacote")]
    public int IdPacote { get; set; }

    [Column("id_destino")]
    public int IdDestino { get; set; }


    //*PROPRIEDADES NAVEGACIONAIS
    public PacoteEntity? Pacote { get; set; }

    public DestinoEntity? Destino { get; set; }
}
