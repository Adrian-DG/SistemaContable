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
    }
}