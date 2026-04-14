using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.NotificacaoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.NotificacaoUseCase.Queries;

public class PesquisarNotificacaoId(INotificacaoRepository repository)
{
    public async Task<NotificacaoResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new NotificacaoResponseDTO
        {
            NotificacaoId = model.Id,
            Titulo = model.Titulo,
            Descricao = model.Descricao,
            DataEnvio = model.DataEnvio,
            OrigemId = model.IdOrigem,
            DestinoId = model.IdDestino
        };
    }
}
