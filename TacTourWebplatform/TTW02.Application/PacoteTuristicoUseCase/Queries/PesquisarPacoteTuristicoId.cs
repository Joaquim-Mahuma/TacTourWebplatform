using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.Queries;

public class PesquisarPacoteTuristicoId(IPacoteRepository repository)
{
    public async Task<PacoteTuristicoResponseDTO?> PesquisarIdAsync(int id)
    {
        var model = await repository.PesquisarPorId(id);
        if (model is null) return null;

        return new PacoteTuristicoResponseDTO
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
        };
    }
}
