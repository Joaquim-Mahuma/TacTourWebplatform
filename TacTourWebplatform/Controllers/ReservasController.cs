using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.Application.Reservas;

namespace TacTourWebplatform.Controllers;

[ApiController]
[Route("api/reservas")]
public class ReservasController(ReservaService servico) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarReservaRequest dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var (id, mensagem) = await servico.CriarAsync(dto);
        if (id == 0)
            return BadRequest(new { mensagem });

        return CreatedAtAction(nameof(Obter), new { id }, new { id, mensagem });
    }

    [HttpGet]
    public async Task<ActionResult<List<ReservaListagemResponse>>> Listar(
        [FromQuery] string? estado,
        [FromQuery] string? texto)
    {
        return Ok(await servico.ListarAsync(estado, texto));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReservaListagemResponse>> Obter(int id)
    {
        var dto = await servico.ObterAsync(id);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpPost("{id:int}/pedir-pagamento")]
    public async Task<IActionResult> PedirPagamento(int id)
    {
        var r = await servico.PedirPagamentoAsync(id);
        return r == "sucesso" ? Ok() : BadRequest(new { mensagem = r });
    }

    [HttpPost("{id:int}/simular-comprovativo")]
    public async Task<IActionResult> SimularComprovativo(int id)
    {
        var r = await servico.SimularComprovativoAsync(id);
        return r == "sucesso" ? Ok() : BadRequest(new { mensagem = r });
    }

    [HttpPost("{id:int}/validar-comprovativo")]
    public async Task<IActionResult> ValidarComprovativo(int id)
    {
        var r = await servico.ValidarComprovativoAsync(id);
        return r == "sucesso" ? Ok() : BadRequest(new { mensagem = r });
    }

    [HttpPost("{id:int}/concluir")]
    public async Task<IActionResult> Concluir(int id)
    {
        var r = await servico.MarcarConcluidaAsync(id);
        return r == "sucesso" ? Ok() : BadRequest(new { mensagem = r });
    }
}
