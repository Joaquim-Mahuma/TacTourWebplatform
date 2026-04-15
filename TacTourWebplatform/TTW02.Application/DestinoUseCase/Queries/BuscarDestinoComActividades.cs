using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.DestinoUseCase.Queries;

public class BuscarDestinoComActividades(IDestinoRepository repository)
{
    public async Task<DestinoComActividadesDTO?> BuscarDestinocomActividadesAsync(int idDestino)
    {
        var model = await repository.BuscarComActividades(idDestino);

        if (model is null)
            return null;

        return new DestinoComActividadesDTO
        {
            DestinoId = model.Id,
            DestinoName = model.Destino,
            TipoDestinoId = model.IdTipoDestino,
            Actividades = model.Actividades.Select(a => new ActividadeDestinoDTO
            {
                ActividadeNome = a.NomeActividade
            }).ToList()
        };
    }
}
