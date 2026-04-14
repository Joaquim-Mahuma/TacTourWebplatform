using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ReservaUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ReservaUseCase.Queries;

public class PesquisarReservaId(IReservaRepository repository)
{
    public async Task<ReservaResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new ReservaResponseDTO
        {
            ReservaId = model.Id,
            TipoReserva = model.TipoReserva,
            DataSolicitacao = model.DataSolicitacao,
            QuantidadePessoas = model.QuantidadePessoas,
            PrecoTotal = model.PrecoTotal,
            EstadoReserva = model.EstadoReserva,
            UsuarioId = model.IdUsuario,
            PacoteId = model.IdPacote
        };
    }
}
