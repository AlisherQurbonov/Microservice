using Microsoft.EntityFrameworkCore;
using platformservice.Entities;

namespace platformservice.Data;

public class AppDbContext : DbContext
{
    public DbSet<Platform> Platforms { get; set; }
   public AppDbContext(DbContextOptions<AppDbContext> options) 
   : base(options){ }
}