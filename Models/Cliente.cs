using System.ComponentModel.DataAnnotations;
using API.Abstraction;
using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Cliente : PersonMetadata
    {
        
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        public string Domicilio { get; set; }

        public ICollection<Prestamo> Prestamos { get; set; }

        public int GetEdad()
        {
            var fechaActual = DateTime.Now;
            
            if((fechaActual.Month >= FechaNacimiento.Month) && (fechaActual.Day >= FechaNacimiento.Day))
            {
                return (fechaActual.Year - FechaNacimiento.Year);
            }

            return (fechaActual.Year - FechaNacimiento.Year) - 1;
        }
    }
}