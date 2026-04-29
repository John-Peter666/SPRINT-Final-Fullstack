using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint_3.Models
{
    [Table("alunos")]
    public class Aluno
    {
        [Key]
        public long idealuno { get; set; }

        [Required, StringLength(50)]
        public string nomaluno { get; set; } = string.Empty;

        [StringLength(20)]
        public string? matricula { get; set; }

        public DateTime? dataNascimento { get; set; }

        [StringLength(100)]
        public string? email { get; set; }

        [StringLength(20)]
        public string? telefone { get; set; }

        [StringLength(11)]
        public string? cpf { get; set; }
    }
}
