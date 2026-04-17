using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("imagem_pacote")]
public class ImagemPacote
{
    [Column("id")]
    public int Id { get; set; }

    [Column("url_image")]
    public string UrlImagem { get; set; } = string.Empty;

    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("id_pacote")]
    public int IdPacote { get; set; }

    public Pacote? Pacote { get; set; }
}
