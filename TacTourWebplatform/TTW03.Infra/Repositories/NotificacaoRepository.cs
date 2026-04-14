using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.Notificacao;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class NotificacaoRepository(TacTourDbContext context)
    : BaseRepository<NotificacaoEntity>(context), INotificacaoRepository
{
    public async Task<IEnumerable<NotificacaoEntity>> ListarPorUsuario(int idUsuario)
    {
        return await this.context.TabelaNotificacao
            .Where(x => x.IdOrigem == idUsuario || x.IdDestino == idUsuario)
            .OrderByDescending(x => x.DataEnvio)
            .ToListAsync();
    }
}
