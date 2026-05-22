using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sprint_3.Data;
using System.Linq;
using System;

namespace Sprint_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BoletimController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoletimController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{alunoId}")]
        public IActionResult GetBoletim(long alunoId)
        {
            var aluno = _context.Alunos.Find(alunoId);
            if (aluno == null) return NotFound("Aluno não encontrado");

            var matriculas = _context.MatriculasDisciplinas
                .Where(m => m.idealuno == alunoId)
                .ToList();

            var resultadoBoletim = matriculas.Select(m => {
                var turma = _context.Turmas.Find(m.ideturma);
                var disciplina = turma != null ? _context.Disciplinas.Find(turma.idedisciplina) : null;
                var professor = turma != null ? _context.Professores.Find(turma.ideprofessor) : null;

                string status = "Em Andamento";
                if (m.nota.HasValue && m.frequencia.HasValue)
                {
                    if (m.frequencia < 75)
                        status = "Reprovado por Frequência";
                    else if (m.nota >= 7)
                        status = "Aprovado";
                    else
                        status = "Reprovado por Nota";
                }

                return new
                {
                    Materia = disciplina?.nomemateria ?? "Não Vinculada",
                    Professor = professor?.nomeprofessor ?? "Não Vinculado",
                    NotaFinal = m.nota, // CORRIGIDO: Removido o espaço em branco que quebrava o código
                    Frequencia = m.frequencia.HasValue ? $"{m.frequencia}%" : "Sem registro",
                    Situacao = status
                };
            }).ToList();

            return Ok(new
            {
                NomeAluno = aluno.nomaluno,
                Matricula = aluno.matricula,
                Boletim = resultadoBoletim
            });
        }
    }
}