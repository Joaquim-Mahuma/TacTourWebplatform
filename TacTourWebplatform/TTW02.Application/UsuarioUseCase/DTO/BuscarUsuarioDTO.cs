using System;

namespace TacTourWebplatform.TTW02.Application.UsuarioUseCase.DTO;

public class BuscarUsuarioDTO
{
    public int Id { get; set; }

    public string NomeUser { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public DateOnly DataNascimento { get; set; }

    public string Nacionalidade { get; set; } = string.Empty;

    public int IdPerfil { get; set; }
}
