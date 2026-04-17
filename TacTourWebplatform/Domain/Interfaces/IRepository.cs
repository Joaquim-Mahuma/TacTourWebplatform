namespace TacTourWebplatform.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<string> Cadastrar(T model);

    Task<string> Actualizar(T model);

    Task<string> Deletar(int id);

    Task<T?> PesquisarPorId(int id);

    Task<IEnumerable<T>> Listagem();
}
