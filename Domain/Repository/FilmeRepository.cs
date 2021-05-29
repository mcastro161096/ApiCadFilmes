using ApiCadFilmes.Domain.Models.Context;
using ApiCadFilmes.Domain.Models.Entities;
using ApiCadFilmes.Domain.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Repository
{
    public class FilmeRepository : BaseRepository, IFilmeRepository
    {
        public FilmeRepository(ApiContext context) : base(context) {}
        

        public Task AddAsync(Filme filme)
        {
            throw new NotImplementedException();
        }

        public Task<Filme> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Filme>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(Filme filme)
        {
            throw new NotImplementedException();
        }

        public void Update(Filme filme)
        {
            throw new NotImplementedException();
        }
    }
}
