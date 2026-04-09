using System;
using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;

public class CadastrarTipoDestinoDTO
{
    [Required(ErrorMessage = "O Tipo de Destino é obrigatório")]
    public string TipoDestinoName {get; set;} = string.Empty;
}
