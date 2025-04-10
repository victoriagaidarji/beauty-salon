using Beauty.Data;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Master> Masters { get; set; }
    public DbSet<MasterService> MasterServices { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Salon> Salons { get; set; }

    /* public ApplicationContext(DbContextOptions<ApplicationContext> options)
    {

    }
    */

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;" +
                                 "Port=5432;" +
                                 "Database=Beauty;" +
                                 "Username=postgres;" +
                                 "Password=1");
        
        /*var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        optionsBuilder.UseNpgsql(connectionString);*/
       
        /*optionsBuilder.UseNpgsql(_config.GetSection("DatabaseConfig")["pg_db"]);*/
    }
}
