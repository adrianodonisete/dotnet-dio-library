using dioLivrariaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace dioLivrariaApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<Produto> todoProducts { get; set; }
    }
}
