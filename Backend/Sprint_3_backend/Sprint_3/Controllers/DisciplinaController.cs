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

        // 🔍 GET TODOS
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Disciplinas.ToList());
        }

        // 🔍 GET POR ID
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var disciplina = _context.Disciplinas.Find(id);

            if (disciplina == null)
                return NotFound("Disciplina não encontrada");

            return Ok(disciplina);
        }

        // ➕ POST
        [HttpPost]
        public IActionResult Post([FromBody] Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();

            return Ok(disciplina);
        }

        // ✏️ PUT
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

        // ❌ DELETE
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
