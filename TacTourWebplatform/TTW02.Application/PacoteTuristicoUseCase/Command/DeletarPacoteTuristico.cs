using TacTourWebplatform.TTW01.Domain.Interface;

namespace TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.Command;

public class DeletarPacoteTuristico(IPacoteRepository repository)
{
    public async Task<string> DeletarAsync(int id)
    {
        return await repository.Deletar(id);
    }
}
