using TacTourWebplatform.TTW01.Domain.Entities.Perfil;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PerfilUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PerfilUseCase.Command;

public class ActualizarPerfil(IPerfilRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarPerfilDTO dto)
    {
        var model = new PerfilEntity
        {
            Id = id,
            TipoPerfil = dto.TipoPerfil
        };

        return await repository.Actualizar(model);
    }
}
