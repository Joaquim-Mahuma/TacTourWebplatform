using TacTourWebplatform.TTW01.Domain.Entities.Notificacao;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.NotificacaoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.NotificacaoUseCase.Command;

public class ActualizarNotificacao(INotificacaoRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarNotificacaoDTO dto)
    {
        var model = new NotificacaoEntity
        {
            Id = id,
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            DataEnvio = dto.DataEnvio,
            IdOrigem = dto.OrigemId,
            IdDestino = dto.DestinoId
        };

        return await repository.Actualizar(model);
    }
}
