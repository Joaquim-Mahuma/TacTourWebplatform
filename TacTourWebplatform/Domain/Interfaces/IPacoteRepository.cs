using TacTourWebplatform.Domain.Entities;

namespace TacTourWebplatform.Domain.Interfaces;

public interface IPacoteRepository : IRepository<Pacote>
{
    Task<IEnumerable<Pacote>> ListarPacotesActivos();

    Task<IEnumerable<Pacote>> ListarPacotesPorDestino(int idDestino);

    Task<IEnumerable<Pacote>> ListarPacotesPorNome(string nome);

    Task<IEnumerable<Pacote>> ListarPacotesPorOperador(int idOperador);

    Task<IEnumerable<Pacote>> ListarComImagensAsync();

    Task<Pacote?> ObterComRelacoesAsync(int id);

    Task AdicionarImagemAsync(int idPacote, string url, string descricao);
}
