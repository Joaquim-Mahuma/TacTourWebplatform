using TacTourWebplatform.Domain.Interfaces;

namespace TacTourWebplatform.Application.Destinos;

public class DestinoService(IDestinoRepository repositorio)
{
    public async Task<List<DestinoResponse>> ListarPorTipoAsync(int idTipo)
    {
        var lista = await repositorio.ListarPorTipo(idTipo);
        return lista.Select(d => new DestinoResponse
        {
            Id = d.Id,
            Nome = d.Nome,
            IdTipoDestino = d.IdTipoDestino,
        }).ToList();
    }
}
