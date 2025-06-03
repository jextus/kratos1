using krat1.Server.Models.Kratos;
using krat1.Server.Services.Seguridad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Krat1.Server.Models;
using Microsoft.AspNetCore.Authorization;

namespace krat1.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly KratosContext _context;
       //private readonly IEncriptarService _encryptionService;

        public EmpresaController(KratosContext context) //IEncriptarService encryptionService)
        {
            _context = context;
            //_encryptionService = encryptionService;
        }

    }
}