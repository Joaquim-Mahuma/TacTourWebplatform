using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.Queries;

public class ListarPacoteNaoIncluidoPorPacote(IPacoteNaoIncluidoRepository repository)
{
    public async Task<List<PacoteNaoIncluidoResponseDTO>> ListarPorPacoteAsync(int pacoteId)
    {
        var models = await repository.ListarPorPacote(pacoteId);

        return models.Select(model => new PacoteNaoIncluidoResponseDTO
        {
            PacoteNaoIncluidoId = model.Id,
            PacoteId = model.IdPacote,
            Descricao = model.Descricao,
            Ordem = model.Ordem
        }).ToList();
    }
}
