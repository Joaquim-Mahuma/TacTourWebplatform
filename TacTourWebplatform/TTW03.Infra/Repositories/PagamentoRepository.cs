using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.Pagamento;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class PagamentoRepository(TacTourDbContext context)
    : BaseRepository<PagamentoEntity>(context), IPagamentoRepository
{
    public async Task<PagamentoEntity?> BuscarPorReserva(int idReserva)
    {
        return await this.context.TabelaPagamento
            .FirstOrDefaultAsync(x => x.IdReserva == idReserva);
    }

    public async Task<IEnumerable<PagamentoEntity>> ListarPorEstado(string estadoPagamento)
    {
        if (string.IsNullOrWhiteSpace(estadoPagamento))
        {
            return [];
        }

        var estado = estadoPagamento.Trim().ToLower();

        return await this.context.TabelaPagamento
            .Where(x => x.EstadoPagamento.ToLower() == estado)
            .ToListAsync();
    }
}
