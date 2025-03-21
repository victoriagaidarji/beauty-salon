using Microsoft.EntityFrameworkCore;
using Photo.Data;

namespace ClassLibrary;

public class ApplicationContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    
    /* public ApplicationContext(DbContextOptions<ApplicationContext> options)
    {

    }
    */
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;" +
                                 "Port=5432;" +
                                 "Database=Photos;" +
                                 "Username=postgres;" +
                                 "Password=1");
        /*var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        optionsBuilder.UseNpgsql(connectionString);*/
       
        /*optionsBuilder.UseNpgsql(_config.GetSection("DatabaseConfig")["pg_db"]);*/
    }
}
