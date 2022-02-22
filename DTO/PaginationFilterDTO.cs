using System;
using System.Collections.Generic;

namespace API.DTO 
{
    public class PaginationFilterDTO<T> where T : class
    {
        public int Pagina { get; set; }
        public int Cantidad { get; set; }
        
        public string Termino { get; set; }
        public bool Estatus { get; set; }
        public string TableName { get; set; }
        public string FilterProp { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaDesde { get; set; }
    }
}