

using Microsoft.EntityFrameworkCore;

namespace API_Example.Data
{
    public class DbContextX : DbContext
    {
        public DbContextX(DbContextOptions<DbContext> options): base(options) 
        {
        
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();    
        }

        public DbSet<Message> Messages { get; set; }

    }
}
