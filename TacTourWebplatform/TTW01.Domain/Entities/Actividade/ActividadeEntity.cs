using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;

namespace TacTourWebplatform.TTW01.Domain.Entities.Actividade;

[Table("actividade")]
public class ActividadeEntity
{


    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("descricao")]
    public string NomeActividade { get; set; } = string.Empty;

    [Column("id_destino")]
    public int IdDestino { get; set; }


    //*PROPRIEDADES NAVEGACIONAIS
    public DestinoEntity? Destino { get; set; }

}
