using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.Application.Equipa;

namespace TacTourWebplatform.Controllers;

[ApiController]
[Route("api/equipa")]
public class EquipaController(EquipaService servico) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<EquipaMembroResponse>>> Listar()
    {
        return Ok(await servico.ListarAsync());
    }
}
