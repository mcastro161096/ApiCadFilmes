using ApiCadFilmes.Domain.Models.Entities;
using ApiCadFilmes.Domain.Models.IServices;
using ApiCadFilmes.Domain.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        public async Task<bool> AddAsync(Genero genero)
        {
          return  await _generoRepository.AddAsync(genero);
        }

        public async Task<Genero> FindByIdAsync(int id)
        {
          return await  _generoRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Genero>> ListAsync()
        {
            return await _generoRepository.ListAsync();
        }

        public async Task<bool> Remove(Genero genero)
        {
          return  await _generoRepository.Remove(genero);
        }

        public async Task<bool> Update(Genero genero)
        {
          return await _generoRepository.Update(genero);
        }

        public async Task<bool> RemoveMany(IEnumerable<Genero> generos)
        {
            return await _generoRepository.RemoveMany(generos);
        }
        public bool GeneroExists(int id)
        {
            return _generoRepository.GeneroExists(id);
        }
    }
}
