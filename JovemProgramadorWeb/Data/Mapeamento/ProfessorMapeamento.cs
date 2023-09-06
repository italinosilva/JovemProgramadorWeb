using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Mapeamento
{
    public class ProfessorMapeamento : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");
            builder.HasKey(t => t.id);
            builder.Property(t => t.nome).HasColumnType("varchar(50)");
            builder.Property(t => t.idade).HasColumnType("int");
            builder.Property(t => t.materia).HasColumnType("varchar(50)");
            builder.Property(t => t.cep).HasColumnType("varchar(20)");
        }
    }
}