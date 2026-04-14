using TacTourWebplatform.TTW01.Domain.Entities.Reserva;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ReservaUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ReservaUseCase.Command;

public class ActualizarReserva(IReservaRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarReservaDTO dto)
    {
        var model = new ReservaEntity
        {
            Id = id,
            TipoReserva = dto.TipoReserva,
            DataSolicitacao = dto.DataSolicitacao,
            QuantidadePessoas = dto.QuantidadePessoas,
            PrecoTotal = dto.PrecoTotal,
            EstadoReserva = dto.EstadoReserva,
            IdUsuario = dto.UsuarioId,
            IdPacote = dto.PacoteId
        };

        return await repository.Actualizar(model);
    }
}
