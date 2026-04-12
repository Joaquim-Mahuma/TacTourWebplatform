using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacTourWebplatform.TTW02.Application.UsuarioUseCase.Command;
using TacTourWebplatform.TTW02.Application.UsuarioUseCase.DTO;

namespace TacTourWebplatform.TTW04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(
        CadastrarUsuario cadastrarUsuarioUseCase
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody]CadastrarUsuarioDTO dto)
        {
            if(!ModelState.IsValid) return StatusCode(400, ModelState);
            var resposta = await cadastrarUsuarioUseCase.CadastrarAsync(dto);
            return resposta.Contains("sucesso") 
            ? StatusCode(200, resposta) 
            : StatusCode(500, resposta);

        }
    }
}
