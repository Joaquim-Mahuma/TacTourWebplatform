using TacTourWebplatform.TTW01.Domain.Entities.Pagamento;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PagamentoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PagamentoUseCase.Command;

public class CadastrarPagamento(IPagamentoRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarPagamentoDTO dto)
    {
        var model = new PagamentoEntity
        {
            ComprovativoUrl = dto.ComprovativoUrl,
            DataPagamento = dto.DataPagamento,
            DataConfirmacao = dto.DataConfirmacao,
            EstadoPagamento = dto.EstadoPagamento,
            IdReserva = dto.ReservaId
        };

        return await repository.Cadastrar(model);
    }
}
