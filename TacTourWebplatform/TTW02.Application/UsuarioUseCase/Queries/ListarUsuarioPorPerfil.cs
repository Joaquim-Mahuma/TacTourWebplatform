using System;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.UsuarioUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.UsuarioUseCase.Queries;

public class ListarUsuarioPorPerfil(IUsuarioRepository repository)
{
    public async Task<IEnumerable<ListarUsuarioPorPerfilDTO>> ListarAsync(int id)
    {
        var models =  await repository.ListarPorPerfil(id);

        return models.Select(model => new ListarUsuarioPorPerfilDTO 
        {
            UsuarioId = model.Id,
            UsuarioNome = model.NomeUser

        }).ToList();
    }
}
