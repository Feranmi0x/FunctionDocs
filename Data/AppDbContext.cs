using Microsoft.EntityFrameworkCore;
using FunctionDocs.Models;

namespace FunctionDocs.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FunctionEntry> FunctionEntries { get; set; } = default!;
    }
}