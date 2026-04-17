using TacTourWebplatform.Domain.Interfaces;

namespace TacTourWebplatform.Application.Equipa;

public class EquipaService(IUsuarioRepository usuarios)
{
    public async Task<List<EquipaMembroResponse>> ListarAsync()
    {
        var lista = await usuarios.ListarEquipaAgenciaAsync();
        return lista.Select(u => new EquipaMembroResponse
        {
            Id = u.Id,
            Nome = u.Nome,
            Email = u.Email,
            Telefone = u.Telefone,
            Perfil = u.Perfil?.TipoPerfil ?? string.Empty,
        }).ToList();
    }
}
