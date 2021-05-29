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
            await _filmeRepository.AddAsync(filme);
        }

        public async Task<Filme> FindByIdAsync(int id)
        {
          return await  _filmeRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Filme>> ListAsync()
        {
            return await _filmeRepository.ListAsync();
        }

        public async Task<bool> Remove(Filme filme)
        {
          return  await _filmeRepository.Remove(filme);
        }

        public async Task<bool> Update(Filme filme)
        {
          return await _filmeRepository.Update(filme);
        }

        public async Task<bool> RemoveMany(IEnumerable<Filme> filmes)
        {
            return await _filmeRepository.RemoveMany(filmes);
        }
        public bool FilmeExists(int id)
        {
            return _filmeRepository.FilmeExists(id);
        }
    }
}
