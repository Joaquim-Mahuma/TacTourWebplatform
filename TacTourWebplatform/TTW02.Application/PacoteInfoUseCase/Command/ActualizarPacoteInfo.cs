using TacTourWebplatform.TTW01.Domain.Entities.PacoteInfo;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.Command;

public class ActualizarPacoteInfo(IPacoteInfoRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarPacoteInfoDTO dto)
    {
        var model = new PacoteInfoEntity
        {
            Id = id,
            IdPacote = dto.PacoteId,
            Descricao = dto.Descricao,
            Ordem = dto.Ordem
        };

        return await repository.Actualizar(model);
    }
}
