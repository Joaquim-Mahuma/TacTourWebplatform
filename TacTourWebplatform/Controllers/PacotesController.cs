using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.Application.Pacotes;

namespace TacTourWebplatform.Controllers;

[ApiController]
[Route("api/pacotes")]
public class PacotesController(PacoteService servico) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PacoteListagemResponse>>> Listar([FromQuery] string? estado)
    {
        return Ok(await servico.ListarAsync(estado));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PacoteDetalheResponse>> Obter(int id)
    {
        var dto = await servico.ObterAsync(id);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarPacoteRequest dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var (id, mensagem) = await servico.CriarAsync(dto);
        if (id == 0)
            return StatusCode(500, mensagem);

        return CreatedAtAction(nameof(Obter), new { id }, new { id, mensagem });
    }

    [HttpPatch("{id:int}/estado")]
    public async Task<IActionResult> AlterarEstado(int id, [FromBody] AlterarEstadoPacoteRequest dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var mensagem = await servico.AlterarEstadoAsync(id, dto);
        return mensagem.Contains("sucesso") ? Ok(new { mensagem }) : StatusCode(500, new { mensagem });
    }
}
