using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Persistence.EntityConfigurations
{
    public class GenreConfigurations:EntityTypeConfiguration<Genre>
    {
        public GenreConfigurations()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}