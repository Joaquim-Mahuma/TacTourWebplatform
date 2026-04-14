using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.NotificacaoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.NotificacaoUseCase.Queries;

public class ListarNotificacaoPorUsuario(INotificacaoRepository repository)
{
    public async Task<List<NotificacaoResponseDTO>> ListarPorUsuarioAsync(int usuarioId)
    {
        var models = await repository.ListarPorUsuario(usuarioId);

        return models.Select(model => new NotificacaoResponseDTO
        {
            NotificacaoId = model.Id,
            Titulo = model.Titulo,
            Descricao = model.Descricao,
            DataEnvio = model.DataEnvio,
            OrigemId = model.IdOrigem,
            DestinoId = model.IdDestino
        }).ToList();
    }
}
