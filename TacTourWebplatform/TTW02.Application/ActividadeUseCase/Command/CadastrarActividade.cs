using TacTourWebplatform.TTW01.Domain.Entities.Actividade;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ActividadeUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ActividadeUseCase.Command;

public class CadastrarActividade(IActividadeRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarActividadeDTO dto)
    {
        var model = new ActividadeEntity
        {
            NomeActividade = dto.ActividadeNome,
            IdDestino = dto.DestinoId
        };

        return await repository.Cadastrar(model);
    }
}
