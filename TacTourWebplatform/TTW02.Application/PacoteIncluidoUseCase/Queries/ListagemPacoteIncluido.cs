using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.Queries;

public class ListagemPacoteIncluido(IPacoteIncluidoRepository repository)
{
    public async Task<List<PacoteIncluidoResponseDTO>> ListagemAsync()
    {
        var models = await repository.Listagem();

        return models.Select(model => new PacoteIncluidoResponseDTO
        {
            PacoteIncluidoId = model.Id,
            PacoteId = model.IdPacote,
            Descricao = model.Descricao,
            Ordem = model.Ordem
        }).ToList();
    }
}
