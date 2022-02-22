using API.DTO;
using System;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IAuthRepository
    {
        Task<ServerResponseDTO> Register(RegisterDTO model);
        Task<LoginResponseDTO> Login(LoginDTO model);
        Task<ServerResponseDTO> ResetPassword(string usuario);
        
    }
}