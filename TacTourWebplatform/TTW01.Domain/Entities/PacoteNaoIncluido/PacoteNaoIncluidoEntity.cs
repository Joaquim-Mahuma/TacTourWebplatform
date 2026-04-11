using System;
using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;

namespace TacTourWebplatform.TTW01.Domain.Entities.PacoteNaoIncluido;


[Table("pacote_nao_incluido")]
public class PacoteNaoIncluidoEntity
{

    [Column("id")]
    public int Id { get; set; }

    [Column("id_pacote")]
    public int IdPacote { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("ordem")]
    public int Ordem { get; set; }

    //*PROPRIEDADES NAVEGACIONAIS
    public PacoteEntity? Pacote { get; set; }

}
