using API.Enums;
using API.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Cuota
    {
        [Key]
        public int Id { get; set; }
        public Decimal Monto { get; set; }
        public Decimal MontoFinal { get; set; }
        public DateTime FechaDePago { get; set; }
        public DateTime FechaAPagar { get; set; }
        public int DiasMora { get; set; }
        public Decimal Recargo { get; set; }

        public Estado Estado { get; set; }

        public Prestamo Prestamo { get; set; }

        public bool Estatus { get; set; }
    }
}