using TacTourWebplatform.TTW01.Domain.Interface;

namespace TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.Command;

public class DeletarPacoteIncluido(IPacoteIncluidoRepository repository)
{
    public async Task<string> DeletarAsync(int id)
    {
        return await repository.Deletar(id);
    }
}
