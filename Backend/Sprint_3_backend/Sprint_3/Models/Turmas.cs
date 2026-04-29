using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint_3.Models
{
    [Table("turmas")]
    public class Turma
    {
        [Key]
        public long idturma { get; set; }

        public long ideprofessor { get; set; }

        public long idedisciplina { get; set; }
    }
}
