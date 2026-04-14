using TacTourWebplatform.TTW01.Domain.Entities.ImagemPacote;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.Command;

public class ActualizarImagemPacote(IImagemPacoteRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarImagemPacoteDTO dto)
    {
        var model = new ImagemPacoteEntity
        {
            Id = id,
            UrlImage = dto.UrlImage,
            DescricaoImage = dto.DescricaoImage,
            IdPacote = dto.PacoteId
        };

        return await repository.Actualizar(model);
    }
}
