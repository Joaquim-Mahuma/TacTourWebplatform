using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.Application.Dashboard;

namespace TacTourWebplatform.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController(DashboardService servico) : ControllerBase
{
    [HttpGet("metricas")]
    public async Task<ActionResult<DashboardMetricasResponse>> Metricas()
    {
        return Ok(await servico.ObterMetricasAsync());
    }

    [HttpGet("resumo")]
    public async Task<ActionResult<DashboardResumoResponse>> Resumo([FromQuery] int limite = 8)
    {
        return Ok(await servico.ObterResumoAsync(limite));
    }
}
