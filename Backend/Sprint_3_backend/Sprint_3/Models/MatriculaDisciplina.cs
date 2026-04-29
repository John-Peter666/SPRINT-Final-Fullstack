using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint_3.Models
{
    [Table("matriculas_disciplinas")]
    public class MatriculaDisciplina
    {
        [Key]
        public long idMatricula { get; set; }

        public long idealuno { get; set; }

        public long ideturma { get; set; }

        public decimal? nota { get; set; }

        public int? frequencia { get; set; }
    }
}
