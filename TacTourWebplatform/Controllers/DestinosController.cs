using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.Application.Destinos;

namespace TacTourWebplatform.Controllers;

[ApiController]
[Route("api/destinos")]
public class DestinosController(DestinoService servico) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<DestinoResponse>>> ListarPorTipo([FromQuery] int tipoId)
    {
        return Ok(await servico.ListarPorTipoAsync(tipoId));
    }
}
