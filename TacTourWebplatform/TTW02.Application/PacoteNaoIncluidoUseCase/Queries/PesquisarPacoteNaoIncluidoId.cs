using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.Queries;

public class PesquisarPacoteNaoIncluidoId(IPacoteNaoIncluidoRepository repository)
{
    public async Task<PacoteNaoIncluidoResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new PacoteNaoIncluidoResponseDTO
        {
            PacoteNaoIncluidoId = model.Id,
            PacoteId = model.IdPacote,
            Descricao = model.Descricao,
            Ordem = model.Ordem
        };
    }
}
