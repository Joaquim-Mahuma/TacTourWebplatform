using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.Application.TiposDestino;

namespace TacTourWebplatform.Controllers;

[ApiController]
[Route("api/tipos-destino")]
public class TiposDestinoController(TipoDestinoService servico) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarTipoDestinoRequest dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var mensagem = await servico.CriarAsync(dto);
        return mensagem.Contains("sucesso") ? StatusCode(201, new { mensagem }) : StatusCode(500, new { mensagem });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarTipoDestinoRequest dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var mensagem = await servico.AtualizarAsync(id, dto);
        return mensagem.Contains("sucesso") ? Ok(new { mensagem }) : StatusCode(500, new { mensagem });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var mensagem = await servico.EliminarAsync(id);
        if (mensagem.Contains("não encontrado", StringComparison.OrdinalIgnoreCase))
            return NotFound(new { mensagem });

        return mensagem.Contains("sucesso") || mensagem.Contains("eliminado", StringComparison.OrdinalIgnoreCase)
            ? Ok(new { mensagem })
            : StatusCode(500, new { mensagem });
    }

    [HttpGet]
    public async Task<ActionResult<List<TipoDestinoResponse>>> Listar()
    {
        return Ok(await servico.ListarAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TipoDestinoResponse>> Obter(int id)
    {
        var dto = await servico.ObterPorIdAsync(id);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpGet("pesquisar")]
    public async Task<ActionResult<TipoDestinoResponse>> Pesquisar([FromQuery] string texto)
    {
        var dto = await servico.PesquisarPorTextoAsync(texto);
        return dto == null ? NotFound() : Ok(dto);
    }
}
