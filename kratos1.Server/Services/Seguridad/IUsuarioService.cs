using krat1.Server.Models.Kratos;

namespace krat1.Server.Services.Seguridad
{
    public interface IUsuarioService
    {
        Task<Empresas> ObtenerEmpresa(string email, string contraseña);
    }
}
