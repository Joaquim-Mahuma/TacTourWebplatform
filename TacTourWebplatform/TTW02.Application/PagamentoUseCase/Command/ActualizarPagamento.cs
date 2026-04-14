using TacTourWebplatform.TTW01.Domain.Entities.Pagamento;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PagamentoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PagamentoUseCase.Command;

public class ActualizarPagamento(IPagamentoRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarPagamentoDTO dto)
    {
        var model = new PagamentoEntity
        {
            Id = id,
            ComprovativoUrl = dto.ComprovativoUrl,
            DataPagamento = dto.DataPagamento,
            DataConfirmacao = dto.DataConfirmacao,
            EstadoPagamento = dto.EstadoPagamento,
            IdReserva = dto.ReservaId
        };

        return await repository.Actualizar(model);
    }
}
