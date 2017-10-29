using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MusicLovers.Core.Models;

namespace MusicLovers.Persistence.EntityConfigurations
{
    public class UserConfigurations:EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfigurations()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(f => f.Followers)
                .WithRequired(f=>f.Followee)
                .WillCascadeOnDelete(false);

            HasMany(f => f.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);

       

        }
    }
}