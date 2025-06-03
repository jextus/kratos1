using Microsoft.AspNetCore.Mvc;
using Krat1.Server.Models;
using System.Security.Cryptography;
using System.Text;
using krat1.Server.Models.Kratos;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace krat1.Server.Services.Seguridad;
public class Usuario : IUsuarioService
{

    private readonly KratosContext _context;
    public Usuario(KratosContext context)
    {
        _context = context;
    }
    public async Task<Empresas> ObtenerEmpresa (string email , string contraseña)
    {
        var empresa = await _context.Empresas
            .Where(e => e.email == email && e.contraseña == contraseña)
            .FirstOrDefaultAsync();
        return empresa;
            
    }
}