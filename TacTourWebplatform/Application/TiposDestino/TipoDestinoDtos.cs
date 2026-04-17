using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.Application.TiposDestino;

public class CriarTipoDestinoRequest
{
    [Required]
    public string Nome { get; set; } = string.Empty;
}

public class AtualizarTipoDestinoRequest
{
    [Required]
    public string Nome { get; set; } = string.Empty;
}

public class TipoDestinoResponse
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;
}
