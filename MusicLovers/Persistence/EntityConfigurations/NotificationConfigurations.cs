using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Persistence.EntityConfigurations
{
    public class NotificationConfigurations:EntityTypeConfiguration<Notification>
    {
        public NotificationConfigurations()
        {
            HasRequired(g => g.Gig);
        }
    }
}