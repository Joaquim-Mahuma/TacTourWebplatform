using System;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;

public class ListarDestinoDTO
{
    public int DestinoId { get; set; }

    public string DestinoName { get; set; } = string.Empty;

    public int TipoDestinoId { get; set; }
}
