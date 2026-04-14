using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.Queries;

public class PesquisarPacoteIncluidoId(IPacoteIncluidoRepository repository)
{
    public async Task<PacoteIncluidoResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new PacoteIncluidoResponseDTO
        {
            PacoteIncluidoId = model.Id,
            PacoteId = model.IdPacote,
            Descricao = model.Descricao,
            Ordem = model.Ordem
        };
    }
}
