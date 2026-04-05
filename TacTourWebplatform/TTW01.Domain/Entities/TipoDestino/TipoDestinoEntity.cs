using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;



namespace TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;

[Table("tipo_destino")]


public class TipoDestinoEntity
{


    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string TipoDestino { get; set; }



    //*PROPRIEDADES NAVEGACIONAIS
    public ICollection<DestinoEntity> Destinos { get; set; } = [];


}