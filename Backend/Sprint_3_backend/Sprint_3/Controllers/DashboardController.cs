using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sprint_3.Data;
using System.Linq;
using System;

namespace Sprint_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Garante que precisa do Token para acessar tudo aqui
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("estatisticas")]
        public IActionResult GetEstatisticas()
        {
            var totalAlunos = _context.Alunos.Count();
            var totalProfessores = _context.Professores.Count();
            var totalDisciplinas = _context.Disciplinas.Count();
            var totalMatriculas = _context.MatriculasDisciplinas.Count();

            // Pega as notas e joga na memória para calcular sem travar o MySQL
            var notas = _context.MatriculasDisciplinas
                .Where(m => m.nota.HasValue)
                .Select(m => m.nota.Value)
                .ToList();

            decimal mediaGeralDaEscola = notas.Any() ? notas.Average() : 0.0m;

            return Ok(new
            {
                AlunosCadastrados = totalAlunos,
                ProfessoresCadastrados = totalProfessores,
                DisciplinasAtivas = totalDisciplinas,
                TotalMatriculasEfetuadas = totalMatriculas,
                MediaGeralDaEscola = Math.Round(mediaGeralDaEscola, 2)
            });
        }
    }
}