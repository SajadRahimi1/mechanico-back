using mechanico.Entities;
using Microsoft.EntityFrameworkCore;

namespace mechanico.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options):base(options){}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Mechanic>().HasKey(mechanic => mechanic.Id);
        modelBuilder.Entity<Address>().HasKey(address => address.Id);
        modelBuilder.Entity<Address>().HasOne<Mechanic>(address =>address.Mechanic ).WithOne(mechanic => mechanic.Address).HasForeignKey<Address>(address=>address.MechanicId);
    }
    
    public override int SaveChanges()
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries()
                     .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            entry.Property("UpdatedAt").CurrentValue = now;

            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = now;
            }
        }
        return base.SaveChanges();
    }
    
    public DbSet<Mechanic> Mechanics { get; set; }
    public DbSet<Address> Addresses { get; set; }
}