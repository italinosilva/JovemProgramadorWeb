using JovemProgramadorWeb.Data.Mapeamento;
using JovemProgramadorWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWeb.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapeamento());
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
