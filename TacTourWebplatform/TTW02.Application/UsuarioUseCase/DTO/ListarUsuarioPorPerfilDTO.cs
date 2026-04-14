using System;

namespace TacTourWebplatform.TTW02.Application.UsuarioUseCase.DTO;

public class ListarUsuarioPorPerfilDTO
{
    public int UsuarioId { get; set; }
    public string UsuarioNome { get; set; } = string.Empty;
    public int UsuarioPerfilId { get; set; }
}
