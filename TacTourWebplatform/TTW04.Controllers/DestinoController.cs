using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.Command;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.Queries;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Commands;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;

namespace TacTourWebplatform.TTW04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController(
        CadastrarDestino cadastrarDestinoUseCase,
        ListarDestinoPorTipo listarDestinoPorTipoUseCase,
        DeletarDestino deletarDestinoUseCase,
        ActualizarDestino actualziarDestinoUseCase
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CadastrarDestino(CadastrarDestinoDTO dto)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelState);

            var resposta = await cadastrarDestinoUseCase.CadastrarAsync(dto);
            return resposta.Contains("sucesso")
            ? StatusCode(201, resposta)
            : StatusCode(500, resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarDestino([FromRoute] int id)
        {
            var resposta = await deletarDestinoUseCase.DeletarAsync(id);
            return resposta.Contains("sucesso")
            ? StatusCode(200, resposta)
            : StatusCode(500, resposta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDestino(int id, ActualizarDestinoDTO dto)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelState);

            var resposta = await actualziarDestinoUseCase.ActualizarAsync(id, dto);
            return resposta.Contains("sucesso") ? StatusCode(200, resposta) : StatusCode(500, resposta);
        }

        [HttpGet("d-portipo/{id}")]
        public async Task<IActionResult> ListarDestinoPorTipo([FromRoute] int id)
        {
            var resposta = await listarDestinoPorTipoUseCase.ListarDestinoPorTipoAsync(id);
            return Ok(resposta);
        }


    }
}
