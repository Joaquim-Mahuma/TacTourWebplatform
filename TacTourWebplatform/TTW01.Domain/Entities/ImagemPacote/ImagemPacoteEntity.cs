using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;

namespace TacTourWebplatform.TTW01.Domain.Entities.ImagemPacote;


[Table("imagem_pacote")]
public class ImagemPacoteEntity
{



    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("url_image")]
    public string UrlImage { get; set; }

    [Column("descricao")]
    public string DescricaoImage { get; set; }

    [Column("id_pacote")]
    public int IdPacote { get; set; }


    //*PROPRIEDADES NAVEGACIONAIS
    public PacoteEntity Pacote { get; set; }

}
