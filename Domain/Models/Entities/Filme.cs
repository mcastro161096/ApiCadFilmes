using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Models.Entities
{
    public class Filme
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Ativo { get; set; }

        public int GeneroId { get; set; }

        [JsonIgnore]
        public virtual Genero Genero { get; set; }
        [JsonIgnore]
        public ICollection<Locacao> Locacoes { get; set; }
    }
}
