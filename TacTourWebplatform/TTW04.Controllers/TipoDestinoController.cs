using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Commands;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;

namespace TacTourWebplatform.TTW04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDestinoController(
        CadastrarTipoDestino cadastrarTipoDestinoUseCase,
        ActualizarTipoDestino actualizarTipoDestinoUseCase
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

    }

}
