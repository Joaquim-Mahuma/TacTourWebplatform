using TacTourWebplatform.TTW01.Domain.Entities.PacoteInfo;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.Command;

public class CadastrarPacoteInfo(IPacoteInfoRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarPacoteInfoDTO dto)
    {
        var model = new PacoteInfoEntity
        {
            IdPacote = dto.PacoteId,
            Descricao = dto.Descricao,
            Ordem = dto.Ordem
        };

        return await repository.Cadastrar(model);
    }
}
