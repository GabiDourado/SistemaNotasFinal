using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaNotasFinal.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Column("AlunoId")]
        [Display(Name = "Código do aluno")]
        public int Id { get; set; }

        [Column("AlunoNome")]
        [Display(Name = "Nome do Aluno")]
        public string NomeAluno { get; set; } = string.Empty;

        [Column("AlunoIdade")]
        [Display(Name = "Idade do aluno")]
        public int IdadeAluno { get; set; }

        [Column("AlunoSerie")]
        [Display(Name = "Série do aluno")]
        public string SerieAluno { get; set; } = string.Empty;
    }
}
