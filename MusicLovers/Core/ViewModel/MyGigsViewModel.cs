using System.Collections.Generic;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Core.ViewModel
{
    public class MyGigsViewModel
    {
        public IEnumerable<Gig> MyGigs { get; set; }
    }
}