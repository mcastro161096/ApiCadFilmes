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
            modelBuilder.Entity<Filme>()
                .HasData(
                new Filme { Id = 1, Nome ="Filme teste", Genero = "Ação", Ativo = 1, DataCriacao = DateTime.Now});

            modelBuilder.Entity<Genero>()
                .HasData(
                new Genero { Id = 1, Nome = "teste", Ativo = 1, DataCriacao = DateTime.Now });
            
        }

    }
}

