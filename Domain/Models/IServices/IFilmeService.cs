using ApiCadFilmes.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Models.IServices
{
    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> ListAsync();
        Task AddAsync(Filme filme);
        Task<Filme> FindByIdAsync(int id);
        Task<bool> Update(Filme filme);
        Task<bool> Remove(Filme filme);
        Task<bool> RemoveMany(IEnumerable<Filme> filmes);
        bool FilmeExists(int id);
    }
}
