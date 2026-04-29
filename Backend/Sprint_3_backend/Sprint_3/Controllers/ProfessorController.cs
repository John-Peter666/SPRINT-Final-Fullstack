using Microsoft.AspNetCore.Mvc;
using Sprint_3.Data;
using Sprint_3.Models;

namespace Sprint_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfessorController(AppDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores.ToList());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var professor = _context.Professores.Find(id);

            if (professor == null)
                return NotFound("Professor não encontrado");

            return Ok(professor);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Professores.Add(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Professor professorAtualizado)
        {
            var professor = _context.Professores.Find(id);

            if (professor == null)
                return NotFound("Professor não encontrado");

            professor.nomeprofessor = professorAtualizado.nomeprofessor;
            professor.email = professorAtualizado.email;
            professor.telefone = professorAtualizado.telefone;

            _context.SaveChanges();

            return Ok(professor);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var professor = _context.Professores.Find(id);

            if (professor == null)
                return NotFound("Professor não encontrado");

            _context.Professores.Remove(professor);
            _context.SaveChanges();

            return Ok("Professor deletado com sucesso");
        }
    }
}
