using MusicLovers.Core.Models.Entities;
using MusicLovers.Persistence;

namespace MusicLovers.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Persistence\Migrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.GenreSet.AddOrUpdate(g => g.Id,
                new Genre() {Id = 1, Name = "Jazz"},
                new Genre() {Id = 2, Name = "Rock"},
                new Genre() {Id = 3, Name = "Country"},
                new Genre() {Id = 4, Name = "Rap"});
        }
    }
}
