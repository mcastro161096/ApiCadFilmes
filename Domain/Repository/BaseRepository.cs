using ApiCadFilmes.Domain.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Repository
{
    public abstract class BaseRepository
    {
        protected readonly ApiContext _context;

        public BaseRepository(ApiContext context)
        {
            _context = context;
        }
    }
}
