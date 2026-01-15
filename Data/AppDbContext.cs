using Microsoft.EntityFrameworkCore;
using BSBESales.Models;

namespace BSBESales.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Sdo> sdos { get; set; }
    public DbSet<Standards> Standards { get; set; }
    public DbSet<SearchStandard> SearchStandards { get; set; }
}