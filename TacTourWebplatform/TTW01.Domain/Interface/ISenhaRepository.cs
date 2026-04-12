using System;
using TacTourWebplatform.TTW01.Domain.Entities.Senha;

namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface ISenhaRepository : IRepository<SenhaEntity>
{
    //Task<SenhaEntity> BuscarPorUsuario(int idUsuario);
}
