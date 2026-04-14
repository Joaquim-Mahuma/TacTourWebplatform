using System;
using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;

public class CadastrarDestinoDTO
{
    [Required(ErrorMessage = "O Nome do Destino é obrigatório")]
    public string DestinoName { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Tipo de Destino é obrigatório")]
    public int TipoDestinoId { get; set; }
}
