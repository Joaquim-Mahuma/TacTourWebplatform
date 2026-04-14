using TacTourWebplatform.TTW01.Domain.Interface;

namespace TacTourWebplatform.TTW02.Application.NotificacaoUseCase.Command;

public class DeletarNotificacao(INotificacaoRepository repository)
{
    public async Task<string> DeletarAsync(int id)
    {
        return await repository.Deletar(id);
    }
}
