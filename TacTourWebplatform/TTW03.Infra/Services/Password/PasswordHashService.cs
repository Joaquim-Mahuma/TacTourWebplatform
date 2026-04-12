using System;
using System.Security.Cryptography;
using TacTourWebplatform.TTW02.Application.Interfaces.Password;

namespace TacTourWebplatform.TTW03.Infra.Services.Password;

public class PasswordHashService : IPasswordHash
{
    //* Cria um hash seguro
    public async Task<(string Hash, string Salt)> HashAsync(string senha)
    {
        //* Gerar salt aleatório de 16 bytes
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        //* Hash Usar PBKDF2 com SHA512 e 100.000 iterações
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(senha, salt, 100000, HashAlgorithmName.SHA512, 64); // 512 bits

        //* Retorna hash e salt como Base64 para gravar no banco
        return await Task.FromResult((Convert.ToBase64String(hash), Convert.ToBase64String(salt)));
    }
}
