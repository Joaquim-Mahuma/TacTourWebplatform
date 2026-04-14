using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PerfilUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PerfilUseCase.Queries;

public class PesquisarPerfilId(IPerfilRepository repository)
{
    public async Task<PerfilResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new PerfilResponseDTO
        {
            PerfilId = model.Id,
            TipoPerfil = model.TipoPerfil
        };
    }
}
