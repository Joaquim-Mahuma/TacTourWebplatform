using TacTourWebplatform.TTW01.Domain.Entities.PacoteNaoIncluido;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.Command;

public class CadastrarPacoteNaoIncluido(IPacoteNaoIncluidoRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarPacoteNaoIncluidoDTO dto)
    {
        var model = new PacoteNaoIncluidoEntity
        {
            IdPacote = dto.PacoteId,
            Descricao = dto.Descricao,
            Ordem = dto.Ordem
        };

        return await repository.Cadastrar(model);
    }
}
