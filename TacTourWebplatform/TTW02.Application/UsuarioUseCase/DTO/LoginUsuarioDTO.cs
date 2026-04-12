using System;
using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.UsuarioUseCase.DTO;

public class LoginUsuarioDTO
{
    [Required(ErrorMessage = "O Email é obrigatório")]
    [EmailAddress(ErrorMessage = "O email não é válido")]
    public string UserEmail { get; set; } = string.Empty;

    [StringLength(100, MinimumLength = 4)]
    [Required(ErrorMessage = "A Senha é obrigatória")]
    public string UserSenha { get; set; } = string.Empty;
}
