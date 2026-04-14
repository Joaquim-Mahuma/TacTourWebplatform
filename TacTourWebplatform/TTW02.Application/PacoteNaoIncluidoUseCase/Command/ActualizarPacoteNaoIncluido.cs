using TacTourWebplatform.TTW01.Domain.Entities.PacoteNaoIncluido;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.Command;

public class ActualizarPacoteNaoIncluido(IPacoteNaoIncluidoRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarPacoteNaoIncluidoDTO dto)
    {
        var model = new PacoteNaoIncluidoEntity
        {
            Id = id,
            IdPacote = dto.PacoteId,
            Descricao = dto.Descricao,
            Ordem = dto.Ordem
        };

        return await repository.Actualizar(model);
    }
}
