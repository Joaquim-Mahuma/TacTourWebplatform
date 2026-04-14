using TacTourWebplatform.TTW01.Domain.Entities.Perfil;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class PerfilRepository(TacTourDbContext context)
    : BaseRepository<PerfilEntity>(context), IPerfilRepository
{
}
