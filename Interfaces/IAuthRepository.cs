using API.DTO;
using API.Models;
using System;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IAuthRepository
    {
        Task<ServerResponseDTO> Register(RegisterDTO model);
        Task<LoginResponseDTO> Login(LoginDTO model);
        Task<ServerResponseDTO> ResetPassword(string usuario);
        Task<bool> CheckIfUserExists(string username);

        string CreateToken(Usuario model);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        
    }
}