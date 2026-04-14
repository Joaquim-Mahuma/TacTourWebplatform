using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.Queries;

public class ListarImagemPacotePorPacote(IImagemPacoteRepository repository)
{
    public async Task<List<ImagemPacoteResponseDTO>> ListarPorPacoteAsync(int pacoteId)
    {
        var models = await repository.ListarPorPacote(pacoteId);

        return models.Select(model => new ImagemPacoteResponseDTO
        {
            ImagemPacoteId = model.Id,
            UrlImage = model.UrlImage,
            DescricaoImage = model.DescricaoImage,
            PacoteId = model.IdPacote
        }).ToList();
    }
}
