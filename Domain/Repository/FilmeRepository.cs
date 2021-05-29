using ApiCadFilmes.Domain.Models.Context;
using ApiCadFilmes.Domain.Models.Entities;
using ApiCadFilmes.Domain.Models.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Repository
{
    public class FilmeRepository : BaseRepository, IFilmeRepository
    {
        public FilmeRepository(ApiContext context) : base(context) {}
        
        /*Aqui eu uso o tipo de retorno Task porque o método não retorna nada, semelhante a um tipo void
         e uso o async para que o método possa aguardar o resulatdo das chamadas que estão sendo feitas usando o await.
        Conforme solicitado nos requisitos técnicos estou usando transaction para garantir a integridade do banco de dados*/
        public async Task AddAsync(Filme filme)
        {
            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            {
                try
                {
                    await _context.Filmes.AddAsync(filme);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception)
                {

                    transaction.Rollback();
                }
            }
            
        }
        //Já aqui uso o tipo de retorno Task<T> porque preciso retornar o filme que foi requisitado
        public async Task<Filme> FindByIdAsync(int id)
        {
            return await _context.Filmes.FindAsync(id);
        }

        public async Task<IEnumerable<Filme>> ListAsync()
        {
            return await _context.Filmes.ToListAsync();
        }

        

        public async Task<bool> Update(Filme filme)
        {
            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            {
                try
                {

                    _context.Filmes.Update(filme);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> Remove(Filme filme)
        {

            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            {
                try
                {

                    _context.Filmes.Remove(filme);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    transaction.Rollback();
                    return false;
                }
            }


        }

        public async Task<bool> RemoveMany(IEnumerable<Filme> filmes)
        {
            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            {
                
                    try
                    {
                        foreach (var filme in filmes)
                        {
                            _context.Filmes.Remove(filme);
                           
                        }
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {

                        transaction.Rollback();
                        return false;
                    }
                
                
            }
        }

        public bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
