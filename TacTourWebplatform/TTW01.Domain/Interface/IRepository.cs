using System;

namespace TacTourWebplatform.TTW01.Domain.Interface;


//* Declaração da Interface-base, onde "<T>" é um espaço em branco que representa
//* um espaço em branco que é ocupado por uma entidade especifica (Ususario, Pacote, etc...)

//* where T :class <--- Para o compilador reconhecer <T> como apenas podendo ser uma CLASSE

public interface IRepository<T> where T : class
{

    
    //Método para cadastrar um registo, recebe um Objecto, retorna uma String
    Task<string> Cadastrar(T entity);

    //Método para actualizar um registo, recebe um Objecto, retorna uma String
    Task<string> Actualizar(T model);

    //Método para deletar um registo, recebe o id e retorna uma String
    Task<string> Deletar(int id);

    //Método para pesquisar um registo, recebe o id e retorna ou não o Objecto
    // Pesquisa feita pelo sistema quando já se conhece o ID.
    Task<T?> PesquisarPorId (int id);

    //Metodo para listar todos os registos, não recebe parametros, retorna uma lista
    //de objectos (os registos)
    Task<IEnumerable<T>> Listagem();

    Task<T> PesquisarPorTexto(string text);


}
