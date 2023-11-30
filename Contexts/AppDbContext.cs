using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace mechanico.Contexts;

public class AppDbContext:DbContext
{
    public static AppDbContext Create(IMongoDatabase database)=>new (new DbContextOptionsBuilder<AppDbContext>().
        UseMongoDB(database.Client,database.DatabaseNamespace.DatabaseName).Options);
        
    public AppDbContext(DbContextOptions options):base(options){}
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}