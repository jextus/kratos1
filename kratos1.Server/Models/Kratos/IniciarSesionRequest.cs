using System.ComponentModel.DataAnnotations;

namespace krat1.Server.Models.Kratos
{
    public class IniciarSesionRequest
    {
        public string email {get; set;}
        public string contraseña {get; set;}
    }
}
