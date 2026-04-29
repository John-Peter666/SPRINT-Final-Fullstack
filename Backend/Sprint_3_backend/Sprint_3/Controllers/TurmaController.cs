using Microsoft.AspNetCore.Mvc;
using Sprint_3.Data;
using Sprint_3.Models;

namespace Sprint_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurmaController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Turmas.ToList());
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Turma turma)
        {
            if (!_context.Professores.Any(p => p.ideprofessor == turma.ideprofessor))
                return BadRequest("Professor não existe");

            if (!_context.Disciplinas.Any(d => d.idedisciplina == turma.idedisciplina))
                return BadRequest("Disciplina não existe");

            _context.Turmas.Add(turma);
            _context.SaveChanges();

            return Ok(turma);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var turma = _context.Turmas.Find(id);

            if (turma == null)
                return NotFound("Turma não encontrada");

            _context.Turmas.Remove(turma);
            _context.SaveChanges();

            return Ok("Turma deletada com sucesso");
        }
    }
}
