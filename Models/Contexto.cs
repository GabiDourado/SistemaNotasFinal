using Microsoft.EntityFrameworkCore;

namespace SistemaNotasFinal.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Bimestre> Bimestre { get; set; }
    }
}
