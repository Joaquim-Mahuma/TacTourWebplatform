using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.Queries;

public class ListagemPacoteInfo(IPacoteInfoRepository repository)
{
    public async Task<List<PacoteInfoResponseDTO>> ListagemAsync()
    {
        var models = await repository.Listagem();

        return models.Select(model => new PacoteInfoResponseDTO
        {
            PacoteInfoId = model.Id,
            PacoteId = model.IdPacote,
            Descricao = model.Descricao,
            Ordem = model.Ordem
        }).ToList();
    }
}
