using TacTourWebplatform.TTW01.Domain.Entities.PacoteIncluido;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.Command;

public class ActualizarPacoteIncluido(IPacoteIncluidoRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarPacoteIncluidoDTO dto)
    {
        var model = new PacoteIncluidoEntity
        {
            Id = id,
            IdPacote = dto.PacoteId,
            Descricao = dto.Descricao,
            Ordem = dto.Ordem
        };

        return await repository.Actualizar(model);
    }
}
