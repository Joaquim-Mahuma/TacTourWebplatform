using System;
using TacTourWebplatform.TTW01.Domain.Entities.ImagemPacote;


namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface IImagemPacoteRepository : IRepository<ImagemPacoteEntity>
{
    Task<IEnumerable<ImagemPacoteEntity>> ListarPorPacote(int idPacote);
}
