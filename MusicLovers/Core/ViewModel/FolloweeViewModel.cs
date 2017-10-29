using System.Collections.Generic;
using MusicLovers.Core.Models;

namespace MusicLovers.Core.ViewModel
{
    public class FolloweeViewModel
    {
        public IEnumerable<ApplicationUser> Followees { get; set; }
    }
}