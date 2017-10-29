﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Persistence.EntityConfigurations
{
    public class FollowingConfigurations:EntityTypeConfiguration<Following>
    {
        public FollowingConfigurations()
        {
            HasKey(g => new { g.FolloweeId, g.FollowerId });

        }
    }
}