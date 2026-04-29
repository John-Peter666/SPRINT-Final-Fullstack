using Microsoft.AspNetCore.Mvc;
using Sprint_3.Data;
using Sprint_3.Models;

namespace Sprint_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisciplinaController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Disciplinas.ToList());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var disciplina = _context.Disciplinas.Find(id);

            if (disciplina == null)
                return NotFound("Disciplina não encontrada");

            return Ok(disciplina);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();

            return Ok(disciplina);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Disciplina disciplinaAtualizada)
        {
            var disciplina = _context.Disciplinas.Find(id);

            if (disciplina == null)
                return NotFound("Disciplina não encontrada");

            disciplina.nomemateria = disciplinaAtualizada.nomemateria;
            disciplina.cargahoraria = disciplinaAtualizada.cargahoraria;
            disciplina.ementa = disciplinaAtualizada.ementa;

            _context.SaveChanges();

            return Ok(disciplina);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var disciplina = _context.Disciplinas.Find(id);

            if (disciplina == null)
                return NotFound("Disciplina não encontrada");

            _context.Disciplinas.Remove(disciplina);
            _context.SaveChanges();

            return Ok("Disciplina deletada com sucesso");
        }
    }
}
