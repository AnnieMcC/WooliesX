using System;
using WooliesX.Core.Models;

namespace WooliesX.Data.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}

