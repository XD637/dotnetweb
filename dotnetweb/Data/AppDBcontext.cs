using dotnetweb.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetweb.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
