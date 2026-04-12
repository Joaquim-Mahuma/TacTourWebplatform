using System;

namespace TacTourWebplatform.TTW02.Application.Interfaces.Password;

public interface IPasswordHash
{
    Task<(string Hash, string Salt)> HashAsync(string senha);
}
