usiusing Sprint_3.Data;
using Sprint_3.Models;

namespace Sprint_3.Services
{
    public class AlunoService
    {
        private readonly AppDbContext _context;

        public AlunoService(AppDbContext context)
        {
            _context = context;
        }

        public List<Aluno> Listar()
        {
            return _context.Alunos.ToList();
        }

        public Aluno Criar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return aluno;
        }

        public Aluno Atualizar(long id, Aluno aluno)
        {
            var existente = _context.Alunos.Find(id);

            if (existente == null) return null;

            existente.nomaluno = aluno.nomaluno;
            existente.email = aluno.email;

            _context.SaveChanges();
            return existente;
        }

        public bool Deletar(long id)
        {
            var aluno = _context.Alunos.Find(id);

            if (aluno == null) return false;

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return true;
        }
    }
}
