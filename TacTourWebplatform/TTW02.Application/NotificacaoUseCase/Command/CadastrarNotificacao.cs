using TacTourWebplatform.TTW01.Domain.Entities.Notificacao;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.NotificacaoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.NotificacaoUseCase.Command;

public class CadastrarNotificacao(INotificacaoRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarNotificacaoDTO dto)
    {
        var model = new NotificacaoEntity
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            DataEnvio = dto.DataEnvio,
            IdOrigem = dto.OrigemId,
            IdDestino = dto.DestinoId
        };

        return await repository.Cadastrar(model);
    }
}
