using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PagamentoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PagamentoUseCase.Queries;

public class PesquisarPagamentoId(IPagamentoRepository repository)
{
    public async Task<PagamentoResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
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
