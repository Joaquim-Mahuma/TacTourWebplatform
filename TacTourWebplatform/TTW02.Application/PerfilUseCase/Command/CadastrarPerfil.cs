using TacTourWebplatform.TTW01.Domain.Entities.Perfil;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PerfilUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PerfilUseCase.Command;

public class CadastrarPerfil(IPerfilRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarPerfilDTO dto)
    {
        var model = new PerfilEntity
        {
            TipoPerfil = dto.TipoPerfil
        };

        return await repository.Cadastrar(model);
    }
}
