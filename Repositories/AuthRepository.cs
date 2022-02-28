using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using API.DTO;
using API.Interfaces;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace SistemaContable.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private APIContext _context;
        private DbSet<Usuario> _userRepo;
        private IConfiguration _configuration;
        public AuthRepository(APIContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> CheckIfUserExists(string username)
        {
            return await _userRepo.AnyAsync<Usuario>(x => x.NombreUsuario == username);
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.ASCIIEncoding.UTF8.GetBytes(password));
            }
        }

        public string CreateToken(Usuario model)
        {
            List<Claim> claims = new List<Claim>
            {
              new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
              new Claim(ClaimTypes.Name, model.NombreUsuario),
              // TODO: must pass the role 
            };
        
            var SecretKey = _configuration.GetSection("SecretKey").Value;
            var SimmetricKey = new SymmetricSecurityKey(ASCIIEncoding.UTF8.GetBytes(SecretKey));
        
            SigningCredentials credentials  = new SigningCredentials(SimmetricKey, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDecriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<LoginResponseDTO> Login(LoginDTO model)
        {
            if(! (await CheckIfUserExists(model.Usuario))) return new LoginResponseDTO { Estatus = false };

            var user = await _context.Usuarios.SingleOrDefaultAsync(x => x.NombreUsuario == model.Usuario);            

            return  VerifyPasswordHash(model.Clave, user.PasswordHash, user.PasswordSalt)
                    ? new LoginResponseDTO { Titulo = "Ok", Mensaje = "Usuario validado!!", Token = CreateToken(user), Estatus = true }
                    : new LoginResponseDTO { Estatus = false };
        }

        public async Task<ServerResponseDTO> Register(RegisterDTO model)
        {
            if(await CheckIfUserExists(model.Usuario)) return new ServerResponseDTO { Titulo = "Fallo", Mensaje = "Fallo al registrar usuario", Estatus = false };

            CreatePasswordHash(model.Clave, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new Usuario
            {
                Cedula = model.Cedula,
                PrimerNombre = model.Nombre,
                PrimerApellido = model.Apellido,
                NombreUsuario = model.Usuario,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var entity = (await _context.Usuarios.AddAsync(user)).Entity;
            return  await _context.SaveChangesAsync() > 0 
                    ? new ServerResponseDTO { Titulo = "Ok", Mensaje = "usuario registrado exitosamente", Estatus = true }
                    : new ServerResponseDTO { Titulo = "Fallo", Mensaje = "Fallo al registrar usuario", Estatus = false };
        }

        public Task<ServerResponseDTO> ResetPassword(string usuario)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(ASCIIEncoding.UTF8.GetBytes(password));
                for (int i=0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i]) return false;    
                }
            }

            return true;
        }

    }
}