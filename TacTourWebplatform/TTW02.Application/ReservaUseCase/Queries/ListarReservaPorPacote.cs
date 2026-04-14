using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ReservaUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ReservaUseCase.Queries;

public class ListarReservaPorPacote(IReservaRepository repository)
{
    public async Task<List<ReservaResponseDTO>> ListarPorPacoteAsync(int pacoteId)
    {
        var models = await repository.ListarReservaPorPacote(pacoteId);

        return models.Select(model => new ReservaResponseDTO
        {
            ReservaId = model.Id,
            TipoReserva = model.TipoReserva,
            DataSolicitacao = model.DataSolicitacao,
            QuantidadePessoas = model.QuantidadePessoas,
            PrecoTotal = model.PrecoTotal,
            EstadoReserva = model.EstadoReserva,
            UsuarioId = model.IdUsuario,
            PacoteId = model.IdPacote
        }).ToList();
    }
}
