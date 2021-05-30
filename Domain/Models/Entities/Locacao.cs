using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Models.Entities
{
    public class Locacao
    {
        public int Id { get; set; }

        public string CpfCliente { get; set; }

        public DateTime DataLocacao { get; set; }

        public ICollection<Filme> Filmes { get; set; }
    }
}
