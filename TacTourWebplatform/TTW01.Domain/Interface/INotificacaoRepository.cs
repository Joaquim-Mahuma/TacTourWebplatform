using System;
using TacTourWebplatform.TTW01.Domain.Entities.Notificacao;

// INotificacaoRepository.cs
namespace TacTourWebplatform.TTW01.Domain.Interface;

public interface INotificacaoRepository : IRepository<NotificacaoEntity>
{
    Task<IEnumerable<NotificacaoEntity>> ListarPorUsuario(int idUsuario);
}