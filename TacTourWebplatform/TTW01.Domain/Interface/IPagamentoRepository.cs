using System;
using TacTourWebplatform.TTW01.Domain.Entities.Pagamento;


namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IPagamentoRepository : IRepository<PagamentoEntity>
{
    Task<PagamentoEntity?> BuscarPorReserva(int idReserva);
    Task<IEnumerable<PagamentoEntity>> ListarPorEstado(string estadoPagamento);
}
