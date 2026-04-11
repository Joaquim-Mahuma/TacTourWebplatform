using System;
using TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;


namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface ITipoDestinoRepository : IRepository<TipoDestinoEntity>
{
    Task<TipoDestinoEntity?> PesquisarPorTexto(string texto);
}