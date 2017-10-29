using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicLovers.Core.Contracts;
using MusicLovers.Core.Contracts.Repositories.Contracts;
using MusicLovers.Core.Models;
using MusicLovers.Core.Models.Entities;
using MusicLovers.Persistence;

namespace MusicLovers.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.GenreSet.ToList();
        }
    }
}