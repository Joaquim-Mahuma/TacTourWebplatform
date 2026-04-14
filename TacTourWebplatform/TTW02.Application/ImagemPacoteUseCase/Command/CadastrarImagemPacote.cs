using TacTourWebplatform.TTW01.Domain.Entities.ImagemPacote;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.Command;

public class CadastrarImagemPacote(IImagemPacoteRepository repository)
{
    public async Task<string> CadastrarAsync(CadastrarImagemPacoteDTO dto)
    {
        var model = new ImagemPacoteEntity
        {
            UrlImage = dto.UrlImage,
            DescricaoImage = dto.DescricaoImage,
            IdPacote = dto.PacoteId
        };

        return await repository.Cadastrar(model);
    }
}
