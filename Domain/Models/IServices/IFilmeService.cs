using ApiCadFilmes.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Models.IServices
{
    interface IFilmeService
    {
        Task<IEnumerable<Filme>> ListAsync();
        Task AddAsync(Filme filme);
        Task<Filme> FindByIdAsync(int id);
        void Update(Filme filme);
        void Remove(Filme filme);
    }
}
