using ApiCadFilmes.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Models.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>(f =>
            {
                f.ToTable("Filmes");
                f.Property(x => x.Nome).IsRequired().HasMaxLength(200);
                f.Property(x => x.Ativo).IsRequired();
                f.Property(x => x.DataCriacao).IsRequired();
                f.HasOne(x => x.Genero).WithMany(x => x.Filmes);
               
                
            });

            modelBuilder.Entity<Genero>( g =>
            {
                g.ToTable<Genero>("Generos");
                g.Property(x => x.Nome).IsRequired().HasMaxLength(100);
               
            });

            modelBuilder.Entity<Locacao>(lo =>
            {
                
                lo.Property(l => l.CpfCliente).IsRequired().HasMaxLength(14);
                lo.Property(l => l.DataLocacao).IsRequired();
            });
            
            
        }

    }
}

