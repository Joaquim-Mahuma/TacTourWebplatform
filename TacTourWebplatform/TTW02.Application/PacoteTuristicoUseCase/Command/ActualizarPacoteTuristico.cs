using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.Command;

public class ActualizarPacoteTuristico(IPacoteRepository repository)
{
    public async Task<string> ActualizarAsync(int id, ActualizarPacoteTuristicoDTO dto)
    {
        var model = new PacoteEntity
        {
            Id = id,
            TituloPacote = dto.TituloPacote,
            DescricaoPacote = dto.DescricaoPacote,
            PrecoBase = dto.PrecoBase,
            DataInicio = dto.DataInicio,
            DataFim = dto.DataFim,
            Duracao = dto.Duracao,
            PontoEncontro = dto.PontoEncontro,
            PontoLargada = dto.PontoLargada,
            EstadoPacote = dto.EstadoPacote,
            IdOperador = dto.OperadorId
        };

        return await repository.Actualizar(model);
    }
}
