using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDBContext : DbContext

    {
        public ApplicationDBContext( DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }


        public DbSet<Stock> stocks { get; set; }
        public DbSet<Comment> comments { get; set; }


    }
}
