using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaNotasFinal.Models
{
    [Table("Professor")]
    public class Professor
    {
        [Column("ProfessorId")]
        [Display(Name = "Código do Professor")]
        public int Id { get; set; }

        [Column("ProfessorNome")]
        [Display(Name = "Nome do Professor")]
        public string NomeProfessor { get; set; } = string.Empty;

        [Column("FormacaoProfessor")]
        [Display(Name = "Formação do Professor")]
        public string ProfessorFormacao { get; set; } = string.Empty;

        [Column("TempoTrabalho")]
        [Display(Name = "Tempo de Trabalho")]
        public string TempoTrabalho { get; set; } = string.Empty;

        [ForeignKey("MateriaId")]
        [Display(Name = "Materia")]
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }
    }
}
