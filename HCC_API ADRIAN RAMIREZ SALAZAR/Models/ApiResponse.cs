namespace HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models
{
    public class ApiResponse
    {
        public int Estatus { get; set; }
        public string Mensaje { get; set; }
        public int Codigo { get; set; }

        // Constructor para respuestas exitosas
        public ApiResponse(string mensaje, int codigo = 1)
        {
            Estatus = 200;
            Mensaje = mensaje;
            Codigo = codigo;
        }

        // Constructor para respuestas de error
        public ApiResponse(string mensajeError, bool esError)
        {
            Estatus = 500;
            Mensaje = mensajeError;
            Codigo = -1;
        }
    }
}
