using System;
using System.ComponentModel.DataAnnotations;
using TacTourWebplatform.TTW01.Domain.Interface;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;

public class ActualizarDestinoDTO
{
    [Required(ErrorMessage = "O Nome do Destino é obrigatório")]
    public string DestinoName { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Tipo do Destino é obrigatório")]
    public int TipoDestinoId { get; set; }
}
