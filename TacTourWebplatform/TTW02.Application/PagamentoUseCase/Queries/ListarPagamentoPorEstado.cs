using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PagamentoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PagamentoUseCase.Queries;

public class ListarPagamentoPorEstado(IPagamentoRepository repository)
{
    public async Task<List<PagamentoResponseDTO>> ListarPorEstadoAsync(string estado)
    {
        var models = await repository.ListarPorEstado(estado);

        return models.Select(model => new PagamentoResponseDTO
        {
            PagamentoId = model.Id,
            ComprovativoUrl = model.ComprovativoUrl,
            DataPagamento = model.DataPagamento,
            DataConfirmacao = model.DataConfirmacao,
            EstadoPagamento = model.EstadoPagamento,
            ReservaId = model.IdReserva
        }).ToList();
    }
}
