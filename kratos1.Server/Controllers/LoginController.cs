using krat1.Server.Models.Kratos;
using krat1.Server.Services.Seguridad;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Krat1.Server.Models;

namespace krat1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly KratosContext _context;
        private readonly IUsuarioService _usuarioService;

        public LoginController(KratosContext context, IUsuarioService usuarioService)
        {
            _context = context;
            _usuarioService = usuarioService;
        }
        [HttpPost]
        [Route("registroUsuario")]
        public async Task<IActionResult> registroUsuario([FromBody] Empresas empresas)
        {
       
            // Valida que la contraseña y la confirmación coincidan
            if (empresas.contraseña != empresas.confirmarContraseña)
            {
                return BadRequest("Error: La contraseña no coincide.");
            }

            // Encripta la contraseña y configura otros datos
            empresas.contraseña = Encriptar.EncriptarClave(empresas.contraseña);
            empresas.confirmarContraseña = Encriptar.EncriptarClave(empresas.confirmarContraseña);
            empresas.creadoEn = DateTime.Now;
      
        
            // Agrega el usuario a la base de datos
            _context.Empresas.Add(empresas);
            await _context.SaveChangesAsync();

            return Ok(empresas);
        }

        

        [HttpPost("iniciarSesion")]
        public async Task<IActionResult> iniciarSesion([FromBody] IniciarSesionRequest request)
        {
            if (string.IsNullOrEmpty(request.email) || string.IsNullOrEmpty(request.contraseña))
            {
                return BadRequest("Por favor, complete todos los campos.");
            }
            request.contraseña = Encriptar.EncriptarClave(request.contraseña);

            var empresa = await _usuarioService.ObtenerEmpresa(request.email, request.contraseña);

            if (empresa == null)
            {
                return BadRequest("Nombre de usuario o contraseña incorrectos.");
            }
            var Claim = new List<Claim>();
            {
                new Claim(ClaimTypes.Name, empresa.email);
            }
            return Ok(new { Message = "Inicio de sesión exitoso", empresa });
        }

        [HttpPost("cerrarSesion")]
        public async Task<IActionResult> cerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok(new { Message = "Sesión cerrada exitosamente" });
        }

    }
}