using Microsoft.AspNetCore.Mvc;
using Sprint_3.Data;
using Sprint_3.Models;

namespace Sprint_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IActionResult Post([FromBody] MatriculaDisciplina matricula)
        {
            
            if (!_context.Alunos.Any(a => a.idealuno == matricula.idealuno))
                return BadRequest("Aluno não existe");

            
            if (!_context.Turmas.Any(t => t.idturma == matricula.ideturma))
                return BadRequest("Turma não existe");

            _context.MatriculasDisciplinas.Add(matricula);
            _context.SaveChanges();

            return Ok(matricula);
        }

        
        [HttpPut("{id}")]
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
