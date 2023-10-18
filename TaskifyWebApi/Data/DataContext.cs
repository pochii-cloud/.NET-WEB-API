using Microsoft.EntityFrameworkCore;
using TaskifyWebApi.Models;

namespace TaskifyWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<Todo> Todos { get; set; }
    }
}
