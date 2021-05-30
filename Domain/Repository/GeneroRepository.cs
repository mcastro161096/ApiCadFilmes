using ApiCadFilmes.Domain.Models.Context;
using ApiCadFilmes.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ApiCadFilmes.Domain.Repository;
using ApiCadFilmes.Domain.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Repository
{
    public class GeneroRepository : BaseRepository, IGeneroRepository
    {
        public GeneroRepository(ApiContext context) : base(context) { }

        
        public async Task<bool> AddAsync(Genero genero)
        {
            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            {
                try
                {
                    await _context.Generos.AddAsync(genero);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    
                    transaction.Rollback();
                    return false;
                }
            }

        }
        public async Task<Genero> FindByIdAsync(int id)
        {
            return await _context.Generos.FindAsync(id);
        }

        public async Task<IEnumerable<Genero>> ListAsync()
        {
            return await _context.Generos.ToListAsync();
        }



        public async Task<bool> Update(Genero genero)
        {
            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            {
                if (GeneroExists(genero.Id))
                {
                    try
                    {

                        _context.Generos.Update(genero);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
        }

        public async Task<bool> Remove(Genero genero)
        {

            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            {
                if (GeneroExists(genero.Id))
                {
                    try
                    {

                        _context.Generos.Remove(genero);
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
                else
                {
                    return false;
                }


            }
        }
            public async Task<bool> RemoveMany(IEnumerable<Genero> generos)
            {
                IDbContextTransaction transaction = _context.Database.BeginTransaction();
                {

                    try
                    {
                        foreach (var genero in generos)
                        {
                            _context.Generos.Remove(genero);

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

            public bool GeneroExists(int id)
            {
                return _context.Generos.Any(e => e.Id == id);
            }
    }
}

