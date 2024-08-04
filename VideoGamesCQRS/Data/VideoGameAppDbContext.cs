using Microsoft.EntityFrameworkCore;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Data
{
    public class VideoGameAppDbContext : DbContext
    {
        public VideoGameAppDbContext(DbContextOptions<VideoGameAppDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; } = null!;
    }
}
