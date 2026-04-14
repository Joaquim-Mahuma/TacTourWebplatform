using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PagamentoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PagamentoUseCase.Queries;

public class ListagemPagamento(IPagamentoRepository repository)
{
    public async Task<List<PagamentoResponseDTO>> ListagemAsync()
    {
        var models = await repository.Listagem();

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
