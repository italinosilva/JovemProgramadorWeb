using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Mapeamento
{
    public class LoginMapeamento : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(t => t.id);
            builder.Property(t => t.nome).HasColumnType("varchar(50)");
            builder.Property(t => t.usuario).HasColumnType("varchar(15)");
            builder.Property(t => t.senha).HasColumnType("varchar(30)");
            builder.Property(t => t.cpf).HasColumnType("varchar(14)");
        }
    }
}