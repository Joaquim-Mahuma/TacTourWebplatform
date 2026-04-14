using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.Queries;

public class ListarPacoteInfoPorPacote(IPacoteInfoRepository repository)
{
    public async Task<List<PacoteInfoResponseDTO>> ListarPorPacoteAsync(int pacoteId)
    {
        var models = await repository.ListarPorPacote(pacoteId);

        return models.Select(model => new PacoteInfoResponseDTO
        {
            PacoteInfoId = model.Id,
            PacoteId = model.IdPacote,
            Descricao = model.Descricao,
            Ordem = model.Ordem
        }).ToList();
    }
}
