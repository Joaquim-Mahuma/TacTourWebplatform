using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.Application.Pacotes;

public class PacoteListagemResponse
{
    public int Id { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public decimal PrecoBase { get; set; }

    public string DataInicio { get; set; } = string.Empty;

    public string DataFim { get; set; } = string.Empty;

    public int DuracaoDias { get; set; }

    public string Estado { get; set; } = string.Empty;

    public string ImagemUrl { get; set; } = string.Empty;

    public int IdOperador { get; set; }
}

public class PacoteDetalheResponse : PacoteListagemResponse
{
    public List<string> Imagens { get; set; } = [];

    public List<ItemOrdenadoResponse> Incluidos { get; set; } = [];

    public List<ItemOrdenadoResponse> NaoIncluidos { get; set; } = [];

    public List<ItemOrdenadoResponse> Informacoes { get; set; } = [];

    public List<ItinerarioResponse> Itinerario { get; set; } = [];
}

public class ItemOrdenadoResponse
{
    public int Ordem { get; set; }

    public string Descricao { get; set; } = string.Empty;
}

public class ItinerarioResponse
{
    public int Ordem { get; set; }

    public string? DestinoNome { get; set; }
}

public class CriarPacoteRequest
{
    [Required]
    public string Titulo { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    [Required]
    public decimal PrecoBase { get; set; }

    [Required]
    public string DataInicio { get; set; } = string.Empty;

    [Required]
    public string DataFim { get; set; } = string.Empty;

    public int DuracaoDias { get; set; }

    public string PontoEncontro { get; set; } = string.Empty;

    public string PontoLargada { get; set; } = string.Empty;

    public string Estado { get; set; } = "rascunho";

    public int IdOperador { get; set; } = 1;

    public string? ImagemUrl { get; set; }
}

public class AlterarEstadoPacoteRequest
{
    [Required]
    public string Estado { get; set; } = string.Empty;
}
