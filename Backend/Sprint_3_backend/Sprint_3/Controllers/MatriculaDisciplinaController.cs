using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sprint_3.Data;
using Sprint_3.Models;
using System.Linq;

namespace Sprint_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Exige que esteja logado
    public class MatriculaDisciplinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MatriculaDisciplinaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.MatriculasDisciplinas.ToList());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Apenas Admin pode matricular
        public IActionResult Post([FromBody] MatriculaDisciplina matricula)
        {
            if (!_context.Alunos.Any(a => a.idealuno == matricula.idealuno))
                return BadRequest("Aluno não existe");

            if (!_context.Turmas.Any(t => t.idturma == matricula.ideturma))
                return BadRequest("Turma não existe");

            // ADICIONADO: Evita duplicidade de matrícula
            var jaMatriculado = _context.MatriculasDisciplinas
                .Any(m => m.idealuno == matricula.idealuno && m.ideturma == matricula.ideturma);

            if (jaMatriculado)
                return BadRequest("Este aluno já está matriculado nesta turma.");

            _context.MatriculasDisciplinas.Add(matricula);
            _context.SaveChanges();

            return Ok(matricula);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Apenas Admin lança nota/frequência
        public IActionResult Put(long id, [FromBody] MatriculaDisciplina atualizado)
        {
            var matricula = _context.MatriculasDisciplinas.Find(id);

            if (matricula == null)
                return NotFound("Matrícula não encontrada");

            matricula.nota = atualizado.nota;
            matricula.frequencia = atualizado.frequencia;

            _context.SaveChanges();

            return Ok(matricula);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(long id)
        {
            var matricula = _context.MatriculasDisciplinas.Find(id);

            if (matricula == null)
                return NotFound("Matrícula não encontrada");

            _context.MatriculasDisciplinas.Remove(matricula);
            _context.SaveChanges();

            return Ok("Matrícula deletada com sucesso");
        }
    }
}