using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Sprint_3.Data;
using Sprint_3.Models;
using Sprint_3.Services;
using System.Linq;
using System;

namespace Sprint_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        // NOVO: Endpoint para cadastrar Usuários e Admins direto na sua tabela 'usuarios'
        [HttpPost("registrar")]
        public IActionResult Registrar([FromBody] Usuario novoUsuario)
        {
            if (_context.Usuarios.Any(u => u.login == novoUsuario.login))
                return BadRequest("Este login já está em uso.");

            if (string.IsNullOrEmpty(novoUsuario.role))
                novoUsuario.role = "User"; // Padrão se não for enviado (Pode ser 'Admin' ou 'User')

            // Criptografa a senha antes de salvar no banco de dados
            novoUsuario.senha = CriptografarSenha(novoUsuario.senha);

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            return Ok(new { mensagem = "Usuário registrado com sucesso!" });
        }

        // ALTERADO: O login agora criptografa a senha recebida para comparar com o banco
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario login)
        {
            var senhaCriptografada = CriptografarSenha(login.senha);

            var user = _context.Usuarios
                .FirstOrDefault(x => x.login == login.login && x.senha == senhaCriptografada);

            if (user == null)
                return Unauthorized("Login ou senha incorretos.");

            var token = _jwtService.GerarToken(user.login, user.role);

            return Ok(new
            {
                token = token,
                usuario = user.login,
                permissao = user.role
            });
        }

        // Função auxiliar para Hashing de Senha (SHA-256)
        private string CriptografarSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}