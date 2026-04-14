using System;
using TacTourWebplatform.TTW01.Domain.Interface;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.Command;


public class DeletarDestino(IDestinoRepository repository)
{
    public async Task<string> DeletarAsync(int id)
    {

        var model = await repository.PesquisarPorId(id); 
        if(model == null) return "Registo não Encontrado";

        return await repository.Deletar(id);
    }
}

