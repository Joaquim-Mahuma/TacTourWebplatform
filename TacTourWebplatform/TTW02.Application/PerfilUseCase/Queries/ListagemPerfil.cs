using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PerfilUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PerfilUseCase.Queries;

public class ListagemPerfil(IPerfilRepository repository)
{
    public async Task<List<PerfilResponseDTO>> ListagemAsync()
    {
        var models = await repository.Listagem();

        return models.Select(model => new PerfilResponseDTO
        {
            PerfilId = model.Id,
            TipoPerfil = model.TipoPerfil
        }).ToList();
    }
}
