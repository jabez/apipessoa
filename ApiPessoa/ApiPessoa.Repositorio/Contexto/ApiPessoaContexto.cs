using ApiPessoa.Dominio.Pessoas;
using ApiPessoa.Repositorio.Mapeamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ApiPessoa.Repositorio.Contexto
{
    public class ApiPessoaContexto : DbContext
    {
        public ApiPessoaContexto(DbContextOptions<ApiPessoaContexto> options) : base(options) {}
        public ApiPessoaContexto() { }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("apipessoa");

            modelBuilder.ApplyConfiguration(new PessoaMapeamento());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Apis; Trusted_Connection = True; MultipleActiveResultSets = true");
#endif
        }
    }
}
