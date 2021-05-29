using ApiCadFilmes.Domain.Models.Entities;
using ApiCadFilmes.Domain.Models.IRepository;
using ApiCadFilmes.Domain.Models.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }
        public async Task AddAsync(Filme filme)
        {
            throw new NotImplementedException();
        }

        public async Task<Filme> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Filme>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(Filme filme)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Filme filme)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveMany(IEnumerable<Filme> filmes)
        {
            throw new NotImplementedException();
        }
        public bool FilmeExists(int id)
        {
            return _filmeRepository.FilmeExists(id);
        }
    }
}
