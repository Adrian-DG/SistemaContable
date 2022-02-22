using API.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Abstraction
{
    public class PersonMetadata : ModelMetadata
    {
        public string Cedula { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public Genero Genero { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }


    }
}