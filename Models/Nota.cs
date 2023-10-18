using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaNotasFinal.Models
{
    [Table("Nota")]
    public class Nota
    {
        [Column("NotaId")]
        [Display(Name = "Código da nota")]
        public int Id { get; set; }

        [ForeignKey("AlunoId")]
        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

        [ForeignKey("MateriaId")]
        [Display(Name = "Materia")]
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }

        [ForeignKey("BimestreId")]
        [Display(Name = "Bimestre")]
        public int BimestreId { get; set; }
        public Bimestre? Bimestre { get; set; }

        [Column("Nota1")]
        [Display(Name = "Primeira Nota do Aluno")]
        public double Notas1 { get; set; }

        [Column("Nota2")]
        [Display(Name = "Segunda Nota do Aluno")]
        public double Notas2 { get; set; }

        [NotMapped]
        public double Media { get { return (Notas1+Notas2) / 2; } }

    }
}

