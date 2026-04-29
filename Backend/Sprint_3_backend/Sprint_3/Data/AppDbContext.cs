using Microsoft.EntityFrameworkCore;
using Sprint_3.Models;
using Sprint_3.Models;

namespace Sprint_3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }


        public DbSet<Professor> Professores { get; set; }

        public DbSet<Disciplina> Disciplinas { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<MatriculaDisciplina> MatriculasDisciplinas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }



    }
}


