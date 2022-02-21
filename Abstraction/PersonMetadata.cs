using API.Enums;

namespace API.Abstraction
{
    public class PersonMetadata : ModelMetadata
    {
        public string Cedula { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Genero Genero { get; set; }

    }
}