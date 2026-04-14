using TacTourWebplatform.TTW01.Domain.Interface;

namespace TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.Command;

public class DeletarPacoteInfo(IPacoteInfoRepository repository)
{
    public async Task<string> DeletarAsync(int id)
    {
        return await repository.Deletar(id);
    }
}
