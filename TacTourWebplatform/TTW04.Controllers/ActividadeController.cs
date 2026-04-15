using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.TTW02.Application.ActividadeUseCase.Command;
using TacTourWebplatform.TTW02.Application.ActividadeUseCase.DTO;
using TacTourWebplatform.TTW02.Application.ActividadeUseCase.Queries;

namespace TacTourWebplatform.TTW04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadeController(
            CadastrarActividade cadastrarActividadeUseCase,
            ActualizarActividade actualizarActividadeUseCase,
            DeletarActividade deletarActividadeUseCase,
            PesquisarActividadeId pesquisarActividadeIdUseCase,
            ListarActividadePorDestino listarActividadePorDestinoUseCase,
            ListagemActividade listagemActividadeUseCase
        ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CadastrarActividade(CadastrarActividadeDTO dto)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelState);

            var resposta = await cadastrarActividadeUseCase.CadastrarAsync(dto);
            return resposta.Contains("sucesso") 
            ? StatusCode(201, resposta) 
            : StatusCode(500, resposta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarActividade(int id, ActualizarActividadeDTO dto)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelState);

            var resposta = await actualizarActividadeUseCase.ActualizarAsync(id, dto);
            return resposta.Contains("sucesso") ? StatusCode(200, resposta) : StatusCode(500, resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarActividade(int id)
        {

            var resposta = await deletarActividadeUseCase.DeletarAsync(id);

            return resposta.Contains("não encontrado") ?
            StatusCode(500, resposta) :
            StatusCode(200, resposta);

        }

        [HttpGet]
        public async Task<IActionResult> ListagemActividade()
        {
            var resposta = await listagemActividadeUseCase.ListagemAsync();
            return Ok(resposta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PesquisarActividadeId(int id)
        {
            var resposta = await pesquisarActividadeIdUseCase.PesquisarIdAsync(id);

            return resposta == null
            ? NotFound("Tipo de Destino não encontrado")
            : Ok(resposta);
        }

        [HttpGet("a-pordestino/{id}")]
        public async Task<IActionResult> ListarActividadePorDestino([FromRoute] int id)
        {
            var resposta = await listarActividadePorDestinoUseCase.ListarPorDestinoAsync(id);
            return Ok(resposta);
        }
    }
}
