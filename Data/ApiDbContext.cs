using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using tweet_service.Models;

namespace tweet_service.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { }
        public DbSet<Tweet> Tweets { get; set; }
    }
}
