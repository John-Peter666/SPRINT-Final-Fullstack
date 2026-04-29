using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint_3.Models
{
    [Table("disciplinas")]
    public class Disciplina
    {
        [Key]
        public long idedisciplina { get; set; }

        [StringLength(50)]
        public string? nomemateria { get; set; }

        [StringLength(30)]
        public string? cargahoraria { get; set; }

        public string? ementa { get; set; }
    }
}
