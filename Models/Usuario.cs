using API.Abstraction;

namespace API.Models
{
    public class Usuario : PersonMetadata
    {
        public string NombreUsuario { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool ReiniciarClave { get; set; }
    }
}