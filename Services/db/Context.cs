using bot.Services.db.Entity;
using Microsoft.EntityFrameworkCore;

namespace bot.Services.db
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
        }

        public DbSet<User> Users{get;set;}
    }
}