using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint_3.Models
{
    [Table("professores")]
    public class Professor
    {
        [Key]
        public long ideprofessor { get; set; }

        [Required, StringLength(50)]
        public string nomeprofessor { get; set; } = string.Empty;

        [StringLength(100)]
        public string? email { get; set; }

        [StringLength(20)]
        public string? telefone { get; set; }
    }
}
