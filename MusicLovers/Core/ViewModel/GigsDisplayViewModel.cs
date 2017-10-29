using System.Collections.Generic;
using System.Linq;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Core.ViewModel
{
    public class GigsDisplayViewModel
    {
        public IEnumerable<Gig> DisplayingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Header { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances { get; set; }
        
    }
}