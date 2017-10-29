using System.Collections.Generic;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Core.Contracts.Repositories.Contracts
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres();
    }
}