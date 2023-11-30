using mechanico.Entities;
using Microsoft.EntityFrameworkCore;

namespace mechanico.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options):base(options){}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Mechanic>().HasKey(_ => _.Id);
    }
    
    public DbSet<Mechanic> Mechanics { get; set; }
}