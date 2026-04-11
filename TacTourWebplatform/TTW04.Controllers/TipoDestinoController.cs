using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Commands;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Queries;

namespace TacTourWebplatform.TTW04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDestinoController(
        CadastrarTipoDestino cadastrarTipoDestinoUseCase,
        ActualizarTipoDestino actualizarTipoDestinoUseCase,
        DeletarTipoDestino deletarTipoDestinoUseCase,
        PesquisarTipoDestinoId pesquisarTipoDestinoIdUseCase,
        PesquisarTipoDestinoTexto pesquisarTipoDestinoTextoUseCase,
        ListagemTipoDestino listagemTipoDestinoUseCase
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CadastrarTipoDestino(CadastrarTipoDestinoDTO dto)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelState);

            var resposta = await cadastrarTipoDestinoUseCase.CadastrarAsync(dto);
            return resposta.Contains("sucesso") ? StatusCode(201, resposta) : StatusCode(500, resposta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTipoDestino(int id, ActualizarTipoDestinoDTO dto)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelState);

            var resposta = await actualizarTipoDestinoUseCase.ActualizarAsync(id, dto);
            return resposta.Contains("sucesso") ? StatusCode(200, resposta) : StatusCode(500, resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTipoDestino(int id)
        {

            var resposta = await deletarTipoDestinoUseCase.DeletarAsync(id);

            return resposta.Contains("não encontrado") ?
            StatusCode(500, resposta) :
            StatusCode(200, resposta);

        }

        [HttpGet]
        public async Task<IActionResult> ListagemTipoDestino()
        {
            var resposta = await listagemTipoDestinoUseCase.ListagemAsync();
            return Ok(resposta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PesquisarTipoDestinoId(int id)
        {
            var resposta = await pesquisarTipoDestinoIdUseCase.PesquisarIdAsync(id);

            return resposta == null 
            ? NotFound("Tipo de Destino não encontrado") 
            : Ok(resposta);
        }

        [HttpGet("pesquisar")]
        public async Task<IActionResult> PesquisarTipoDestinoTexto([FromQuery] string texto)
        {
            var resposta = await pesquisarTipoDestinoTextoUseCase.PesquisarTextoAsync(texto);
            return resposta == null 
            ? NotFound($"Nenhum tipo de destino encontrado com o texto: {texto}") 
            : Ok(resposta);
        }
    }

}
