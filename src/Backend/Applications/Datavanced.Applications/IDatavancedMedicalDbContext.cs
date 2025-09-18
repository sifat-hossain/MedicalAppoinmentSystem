namespace Datavanced.Applications;

public interface IDatavancedMedicalDbContext
{
    DbSet<Patient> Patient { get; set; }
    DbSet<Doctor> Doctor { get; set; }
    DbSet<Appointment> Appointment { get; set; }
    DbSet<Prescription> Prescription { get; set; }
    DbSet<Medicine> Medicine { get; set; }


    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
