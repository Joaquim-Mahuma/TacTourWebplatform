using System;
using TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.DTO;


namespace TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Commands;

//^ O Use Case recebe o repository por injecção de dependências
public class DeletarTipoDestino(ITipoDestinoRepository repository)
{
    //^ O método principal — recebe o DTO e devolve um resultado
    public async Task<string> DeletarAsync(int id)
    {
        //^ 1. Converte o DTO numa Entity
        var model = await repository.PesquisarPorId(id); 
        if(model == null) return "Registo não Encontrado";

        //^ 2. Chama o Repository para guardar no banco
        return await repository.Deletar(id);
    }
}
