using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaNotasFinal.Models
{
    [Table("Bimestre")]
    public class Bimestre
    {
        [Column("BimestreId")]
        [Display(Name = "código do bimestre")]
        public int Id { get; set; }

        [Column("AnoBimestre")]
        [Display(Name = "Ano do bimestre")]
        public int BimestreAno { get; set; }

        [Column("BimestreDescricao")]
        [Display(Name = "Descrição do bimestre")]
        public string BimestreDescricao { get; set; } = string.Empty;
    }
}
