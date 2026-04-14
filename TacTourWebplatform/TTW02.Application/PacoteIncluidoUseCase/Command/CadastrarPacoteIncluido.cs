using TacTourWebplatform.TTW01.Domain.Entities.PacoteIncluido;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.Command;

public class CadastrarPacoteIncluido(IPacoteIncluidoRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarPacoteIncluidoDTO dto)
    {
        var model = new PacoteIncluidoEntity
        {
            IdPacote = dto.PacoteId,
            Descricao = dto.Descricao,
            Ordem = dto.Ordem
        };

        return await repository.Cadastrar(model);
    }
}
