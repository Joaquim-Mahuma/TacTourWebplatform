using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.Queries;

public class ListarPacoteTuristicoActivo(IPacoteRepository repository)
{
    public async Task<List<PacoteTuristicoResponseDTO>> ListarActivosAsync()
    {
        var models = await repository.ListarPacotesActivos();

        return models.Select(model => new PacoteTuristicoResponseDTO
        {
            PacoteTuristicoId = model.Id,
            TituloPacote = model.TituloPacote,
            DescricaoPacote = model.DescricaoPacote,
            PrecoBase = model.PrecoBase,
            DataInicio = model.DataInicio,
            DataFim = model.DataFim,
            Duracao = model.Duracao,
            PontoEncontro = model.PontoEncontro,
            PontoLargada = model.PontoLargada,
            EstadoPacote = model.EstadoPacote,
            OperadorId = model.IdOperador
        }).ToList();
    }
}
