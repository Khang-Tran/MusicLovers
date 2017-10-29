using System.Collections.Generic;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Core.Contracts.Repositories.Contracts
{
    public interface IGigRepository
    {
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithAttendee(int gigId);
        IEnumerable<Gig> GetGigWithGenre(int gigId);
        Gig GetGigWithId(int gigId);
        IEnumerable<Gig> GetAllUpcomingGigs();
        IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId);
        void Add(Gig gig);
    }
}