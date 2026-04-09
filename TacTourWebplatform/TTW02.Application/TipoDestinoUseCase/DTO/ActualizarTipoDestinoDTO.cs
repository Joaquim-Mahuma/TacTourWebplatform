using System;
using System.ComponentModel.DataAnnotations;

namespace TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;

public class ActualizarTipoDestinoDTO
{
    [Required(ErrorMessage = "O campo TIPO DE DESTINO é obrigatório")]
    public string TipoDestinoName {get; set;} = string.Empty;
}
