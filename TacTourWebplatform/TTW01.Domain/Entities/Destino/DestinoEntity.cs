using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Actividade;
using TacTourWebplatform.TTW01.Domain.Entities.Itinerario;
using TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;

namespace TacTourWebplatform.TTW01.Domain.Entities.Destino;



[Table("destino")]
public class DestinoEntity
{


    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string Destino { get; set; }

    [Column("id_tipo")]
    public int IdTipoDestino { get; set; }


    //*PROPRIEDADES NAVEGACIONAIS
    public ICollection<ItinerarioEntity> Itinerarios { get; set; } = [];

    public ICollection<ActividadeEntity> Actividades { get; set; } = [];

    public TipoDestinoEntity TipoDestino { get; set; }


}