using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.Queries;

public class ListarPacoteIncluidoPorPacote(IPacoteIncluidoRepository repository)
{
    public async Task<List<PacoteIncluidoResponseDTO>> ListarPorPacoteAsync(int pacoteId)
    {
        var models = await repository.ListarPorPacote(pacoteId);

        return models.Select(model => new PacoteIncluidoResponseDTO
        {
            PacoteIncluidoId = model.Id,
            PacoteId = model.IdPacote,
            Descricao = model.Descricao,
            Ordem = model.Ordem
        }).ToList();
    }
}
