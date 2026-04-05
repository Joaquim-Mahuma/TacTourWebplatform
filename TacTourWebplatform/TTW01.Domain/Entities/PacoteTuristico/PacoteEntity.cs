using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using TacTourWebplatform.TTW01.Domain.Entities.ImagemPacote;
using TacTourWebplatform.TTW01.Domain.Entities.Itinerario;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteIncluido;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteInfo;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteNaoIncluido;
using TacTourWebplatform.TTW01.Domain.Entities.Reserva;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;


namespace TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;


[Table("pacote_turistico")]
public class PacoteEntity
{


    //*PROPRIEDADES DA CLASSE (Caracteristícas)
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    public string TituloPacote { get; set; }

    [Column("descricao")]
    public string DescricaoPacote { get; set; }

    [Column("preco_base")]
    public decimal PrecoBase { get; set; }

    [Column("data_inicio")]
    public DateOnly DataInicio { get; set; }

    [Column("data_fim")]
    public DateOnly DataFim { get; set; }

    [Column("duracao")]
    public int Duracao { get; set; }

    [Column("ponto_encontro")]
    public string PontoEncontro { get; set; }

    [Column("ponto_largada")]
    public string PontoLargada { get; set; }

    [Column("estado")]
    public string EstadoPacote { get; set; }

    [Column("id_operador")]
    public int IdOperador { get; set; }


    //*PROPRIEDADES NAVEGACIONAIS


    public UsuarioEntity Operador { get; set; }

    public ICollection<PacoteIncluidoEntity> ItensIncluidos { get; set; } = [];

    public ICollection<PacoteNaoIncluidoEntity> ItensNaoIncluidos { get; set; } = [];

    public ICollection<PacoteInfoEntity> InfoImportantes { get; set; } = [];

    public ICollection<ReservaEntity> Reservas { get; set; } = [];

    public ICollection<ItinerarioEntity> Itinerarios { get; set; } = [];

    public ICollection<ImagemPacoteEntity> Imagens { get; set; } = [];




}
