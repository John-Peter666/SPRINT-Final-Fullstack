using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sprint_3.DTOs;
using Sprint_3.Models;
using Sprint_3.Services;

namespace Sprint_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _service;

        public AlunoController(AlunoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Listar());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AlunoDTO dto)
        {
            var aluno = new Aluno
            {
                nomaluno = dto.nomaluno,
                email = dto.email
            };

            return Ok(_service.Criar(aluno));
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] AlunoDTO dto)
        {
            var aluno = new Aluno
            {
                nomaluno = dto.nomaluno,
                email = dto.email
            };

            var atualizado = _service.Atualizar(id, aluno);

            if (atualizado == null) return NotFound();

            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var ok = _service.Deletar(id);

            if (!ok) return NotFound();

            return Ok();
        }
    }
}
