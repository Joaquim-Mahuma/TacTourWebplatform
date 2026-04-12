using System;
using TacTourWebplatform.TTW01.Domain.Entities.Senha;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.Interfaces.Password;
using TacTourWebplatform.TTW02.Application.UsuarioUseCase.DTO;

namespace TacTourWebplatform.TTW02.Application.UsuarioUseCase.Command;

public class CadastrarUsuario(
    IUsuarioRepository repository, 
    IPasswordHash password, 
    ISenhaRepository auth)
{
    public async Task<string> CadastrarAsync(CadastrarUsuarioDTO dto)
    {

        var user = await repository.PesquisarPorEmail(dto.UserEmail);
        if(user is not null) return "Este email já é existente";


        var model = new UsuarioEntity
        {
            NomeUser = dto.UserNome,
            Email = dto.UserEmail,
            Telefone = dto.UserTelefone,
            Nacionalidade = dto.UserNacionalidade,
            DataNascimento = dto.UserDataNascimento

        };
        var (message, id) = await repository.CadastrarUsuario(model);

        if (!message.Contains("sucesso")) return message;

        var (senhaHash, SaltHash) = await password.HashAsync(dto.UserSenha);

        var senha = new SenhaEntity
        {
            IdUsuario = id,
            SenhaHash = senhaHash,
            SenhaSalt = SaltHash
        };
        var m = await auth.Cadastrar(senha);

        return message;

    }
}
