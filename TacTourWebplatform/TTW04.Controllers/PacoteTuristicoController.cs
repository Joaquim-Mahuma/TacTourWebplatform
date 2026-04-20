using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.Command;
using TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.DTO;

namespace TacTourWebplatform.TTW04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacoteTuristicoController(
        CadastrarPacoteTuristico cadastrarPacoteTuristicoUseCase
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CadastartrarPacoteTuristico(CadastrarPacoteTuristicoDTO dto)
        {
            if(!ModelState.IsValid) return StatusCode(400, ModelState);

            var resposta = await cadastrarPacoteTuristicoUseCase.CadastrarAsync(dto);
            return resposta.Contains("sucesso") 
            ? StatusCode(200, resposta) 
            : StatusCode(500, resposta);
        }
    }
}
