using ApiPessoa.Dominio.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPessoa.Repositorio.Mapeamento
{
    public class PessoaMapeamento : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOA");

            builder.Property(p => p.Id).HasColumnName("ID_PESSOA").ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).IsRequired().HasColumnName("NM_NOME");
            builder.Property(p => p.DataNascimento).IsRequired().HasColumnName("DT_NASCIMENTO");
            builder.Property(p => p.Sexo).IsRequired().HasColumnName("CD_SEXO");
            builder.Property(p => p.Cpf).IsRequired().HasColumnName("TX_CPF");
        }
    }
}
