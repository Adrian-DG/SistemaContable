using System.ComponentModel.DataAnnotations;
using System;

namespace API.Abstraction
{
    public class ModelMetadata
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; }
        public bool Estatus { get; set; }
    }
}