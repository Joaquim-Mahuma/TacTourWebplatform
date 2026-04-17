using TacTourWebplatform.Domain.Entities;

namespace TacTourWebplatform.Domain.Interfaces;

public interface ITipoDestinoRepository : IRepository<TipoDestino>
{
    Task<TipoDestino?> PesquisarPorTexto(string texto);
}
