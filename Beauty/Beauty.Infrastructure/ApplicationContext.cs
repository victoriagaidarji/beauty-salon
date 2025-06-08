using Beauty.Data;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Procedure> Procedures { get; set; }
    public DbSet<Master> Masters { get; set; }
    public DbSet<MasterProcedure> MasterProcedures { get; set; }
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

        // 2. Настройка many-to-many Master ↔ Procedure
        modelBuilder.Entity<MasterProcedure>()
            .HasKey(mps => new { mps.MasterId, mps.ProcedureId });

        modelBuilder.Entity<MasterProcedure>()
            .HasOne(mps => mps.Master)
            .WithMany(m => m.MasterServices)
            .HasForeignKey(mps => mps.MasterId);

        modelBuilder.Entity<MasterProcedure>()
            .HasOne(mps => mps.Procedure)
            .WithMany(ps => ps.MasterServices)
            .HasForeignKey(mps => mps.ProcedureId);
        
        // Глобальный фильтр для мастеров — показывать только активных по умолчанию
        modelBuilder.Entity<Master>().HasQueryFilter(m => m.IsActive);
    }
}