using ApiCadFilmes.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Models.IRepository
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> ListAsync();
        Task<bool> AddAsync(Genero genero);
        Task<Genero> FindByIdAsync(int id);
        Task<bool> Update(Genero genero);
        Task<bool> Remove(Genero genero);
        Task<bool> RemoveMany(IEnumerable<Genero> generos);
        bool GeneroExists(int id);
    }
}
