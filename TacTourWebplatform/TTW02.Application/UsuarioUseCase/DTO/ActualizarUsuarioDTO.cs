using System;
using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.UsuarioUseCase.DTO;

public class ActualizarUsuarioDTO
{

    [Required(ErrorMessage = "O Id é obrigatório")]
    public int UserId { get; set; }



    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string UserNome { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "O email não é válido")]
    [Required(ErrorMessage = "O Email é obrigatório")]
    public string UserEmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Telefone é obrigatório")]
    public string UserTelefone { get; set; } = string.Empty;

    [Required]
    public string UserNacionalidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "A Senha é obrigatória")]
    [StringLength(100, MinimumLength = 4)]
    public string UserSenha { get; set; } = string.Empty;

}
