using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.Queries;

public class PesquisarPacoteInfoId(IPacoteInfoRepository repository)
{
    public async Task<PacoteInfoResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new PacoteInfoResponseDTO
        {
            PacoteInfoId = model.Id,
            PacoteId = model.IdPacote,
            Descricao = model.Descricao,
            Ordem = model.Ordem
        };
    }
}
