namespace Datavanced.Infrastructures;

public class DatavancedMedicalDbContext(DbContextOptions options) : DbContext(options), IDatavancedMedicalDbContext
{
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Appointment> Appointment { get; set; }
    public DbSet<Prescription> Prescription { get; set; }
    public DbSet<Medicine> Medicine { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatavancedMedicalDbContext).Assembly);
    }

    public override int SaveChanges()
    {
        foreach (EntityEntry entityEntry in ChangeTracker.Entries())
        {
            if (entityEntry.Entity is BaseEntity baseEntity)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    baseEntity.CreatedOn = DateTime.UtcNow;
                    baseEntity.ModifiedOn = null;
                }
                if (entityEntry.State == EntityState.Modified)
                {
                    baseEntity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (EntityEntry entityEntry in ChangeTracker.Entries())
        {
            if (entityEntry.Entity is BaseEntity baseEntity)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    baseEntity.CreatedOn = DateTime.UtcNow;
                    baseEntity.ModifiedOn = null;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    baseEntity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
