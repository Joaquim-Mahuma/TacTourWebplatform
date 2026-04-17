using System.ComponentModel.DataAnnotations.Schema;

namespace TacTourWebplatform.Domain.Entities;

[Table("pacote_turistico")]
public class Pacote
{
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    public string Titulo { get; set; } = string.Empty;

    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("preco_base")]
    public decimal PrecoBase { get; set; }

    [Column("data_inicio")]
    public DateOnly DataInicio { get; set; }

    [Column("data_fim")]
    public DateOnly DataFim { get; set; }

    [Column("duracao")]
    public int Duracao { get; set; }

    [Column("ponto_encontro")]
    public string PontoEncontro { get; set; } = string.Empty;

    [Column("ponto_largada")]
    public string PontoLargada { get; set; } = string.Empty;

    [Column("estado")]
    public string Estado { get; set; } = string.Empty;

    [Column("id_operador")]
    public int IdOperador { get; set; }

    public Usuario? Operador { get; set; }

    public ICollection<PacoteIncluido> ItensIncluidos { get; set; } = [];

    public ICollection<PacoteNaoIncluido> ItensNaoIncluidos { get; set; } = [];

    public ICollection<PacoteInfo> InfoImportantes { get; set; } = [];

    public ICollection<Reserva> Reservas { get; set; } = [];

    public ICollection<Itinerario> Itinerarios { get; set; } = [];

    public ICollection<ImagemPacote> Imagens { get; set; } = [];
}
