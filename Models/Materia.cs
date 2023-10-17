using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaNotasFinal.Models
{
    [Table("Materia")]
    public class Materia
    {
        [Column("MateriaId")]
        [Display(Name = "código da materia")]
        public int Id { get; set; }

        [Column("MateriaNome")]
        [Display(Name = "Nome da Materia")]
        public string MateriaNome { get; set; } = string.Empty;
    }
}
