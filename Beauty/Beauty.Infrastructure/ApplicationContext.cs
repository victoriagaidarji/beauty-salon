using Beauty.Data;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ProfessionalService> ProfessionalServices { get; set; }
    public DbSet<Master> Masters { get; set; }
    public DbSet<MasterProfessionalService> MasterServices { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Salon> Salons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;" +
                                 "Port=5432;" +
                                 "Database=Beauty;" +
                                 "Username=postgres;" +
                                 "Password=1");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Настройка one-to-one между Appointment и Payment
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Payment)
            .WithOne(p => p.Appointment)
            .HasForeignKey<Payment>(p => p.AppointmentId);

        // 2. Настройка many-to-many Master ↔ ProfessionalService
        modelBuilder.Entity<MasterProfessionalService>()
            .HasKey(mps => new { mps.MasterId, mps.ProfessionalServiceId });

        modelBuilder.Entity<MasterProfessionalService>()
            .HasOne(mps => mps.Master)
            .WithMany(m => m.MasterServices)
            .HasForeignKey(mps => mps.MasterId);

        modelBuilder.Entity<MasterProfessionalService>()
            .HasOne(mps => mps.ProfessionalService)
            .WithMany(ps => ps.MasterServices)
            .HasForeignKey(mps => mps.ProfessionalServiceId);
    }
}