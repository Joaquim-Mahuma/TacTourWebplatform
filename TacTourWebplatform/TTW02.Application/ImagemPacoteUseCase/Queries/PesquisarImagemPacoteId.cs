using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.Queries;

public class PesquisarImagemPacoteId(IImagemPacoteRepository repository)
{
    public async Task<ImagemPacoteResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new ImagemPacoteResponseDTO
        {
            ImagemPacoteId = model.Id,
            UrlImage = model.UrlImage,
            DescricaoImage = model.DescricaoImage,
            PacoteId = model.IdPacote
        };
    }
}
