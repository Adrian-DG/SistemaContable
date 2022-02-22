namespace API.DTO
{
    public class ServerResponseDTO
    {
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public bool Estatus { get; set; }


        public ServerResponseDTO GetOkResponse()
        {
            return new ServerResponseDTO() 
            { 
                Titulo = "Proceso exitoso", 
                Mensaje = "Se guardaron los cambios de forma exitosa", 
                Estatus = true 
            };
        }

        public ServerResponseDTO GetBadResponse()
        {
            return new ServerResponseDTO()
            {
                Titulo = "Proceso fallido",
                Mensaje = "El proceso fallo, algo salio mal!!",
                Estatus = false
            };
        }


    }
    
}