using TacTourWebplatform.TTW01.Domain.Interface;

namespace TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.Command;

public class DeletarPacoteNaoIncluido(IPacoteNaoIncluidoRepository repository)
{
    public async Task<string> DeletarAsync(int id)
    {
        return await repository.Deletar(id);
    }
}
