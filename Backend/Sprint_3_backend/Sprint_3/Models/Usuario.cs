using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint_3.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public long id { get; set; }

        public string login { get; set; }
        public string senha { get; set; }
        public string? role { get; set; }
    }
}
