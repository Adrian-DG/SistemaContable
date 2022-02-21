using System;
using API.Abstraction;
using System.ComponentModel.DataAnnotations;
using API.Enums;
using System.Collections.Generic;

namespace API.Models
{
    public class Prestamo : ModelMetadata
    {
        public Decimal MontoSolicitado { get; set; }
        public Decimal MontoAPagar { get; set; }
        public DateTime FechaASaldar { get; set; }
        public Decimal TasaInteres { get; set; }
        public int NCuotas { get; set; }
        public Modalidad Modalidad { get; set; }
        public Estado Estado { get; set; }

        public Cliente Cliente { get; set; }
        public ICollection<Cuota> Cuotas { get; set; }
      
    }
}