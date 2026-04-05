using System;

using System;
using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.ImagemPacote;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;

namespace TacTourWebplatform.TTW03.Infra.Repositories;

public class ImagemRepository(TacTourDbContext context) : ICadastrarRepository<ImagemPacoteEntity>,
                                                            IListagemRepository<ImagemPacoteEntity>,
                                                            IPesquisarRepository<ImagemPacoteEntity>,
                                                            IActualizarRepository<ImagemPacoteEntity>,
                                                            IApagarRepository<ImagemPacoteEntity>

{
    public async Task<string> Actualizar(ImagemPacoteEntity model)
    {
        context.TabelaImagemPacote.Update(model);
        return await context.SaveChangesAsync() > 0 ?
        "Imagem actualizado com sucesso" :
        "Não foi possível actualizar a Imagem";
    }

    public async Task<string> Apagar(ImagemPacoteEntity model)
    {
        context.TabelaImagemPacote.Remove(model);
        return await context.SaveChangesAsync() > 0 ?
        "Imagem apagada com sucesso" :
        "Não foi possível apagar a Imagem";

    }

    public async Task<string> Cadastrar(ImagemPacoteEntity model)
    {
        await context.TabelaImagemPacote.AddAsync(model);
        return await context.SaveChangesAsync() > 0 ?
        "Imagem cadastrado com sucesso" :
        "Não foi possível cadastrar a Imagem";

    }

    public async Task<IEnumerable<ImagemPacoteEntity>> Listagem()
    {
        return await context.TabelaImagemPacote.Include(imagem => imagem.IdPacote).ToListAsync();

    }

    public async Task<ImagemPacoteEntity?> Pesquisar(int id)
    {
        return await context.TabelaImagemPacote.Include(imagem => imagem.IdPacote).FirstOrDefaultAsync(x => x.Id == id);
    }
}
