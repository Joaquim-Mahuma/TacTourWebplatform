using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PagamentoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PagamentoUseCase.Queries;

public class PesquisarPagamentoPorReserva(IPagamentoRepository repository)
{
    public async Task<PagamentoResponseDTO?> PesquisarPorReservaAsync(int reservaId)
    {
        var model = await repository.BuscarPorReserva(reservaId);
        if (model is null) return null;

        return new PagamentoResponseDTO
        {
            PagamentoId = model.Id,
            ComprovativoUrl = model.ComprovativoUrl,
            DataPagamento = model.DataPagamento,
            DataConfirmacao = model.DataConfirmacao,
            EstadoPagamento = model.EstadoPagamento,
            ReservaId = model.IdReserva
        };
    }
}
