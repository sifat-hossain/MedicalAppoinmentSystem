namespace Datavanced.Infrastructures.Configurations;

public class Appointmentfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable(nameof(Appointment), b => b.IsTemporal());

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.AppoitmentDate)
            .IsRequired()
            .HasColumnType(Constants.Precision.DateTime);

        builder.Property(b => b.Diagnosis)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Note);

        builder.Property(b => b.VisitType)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Number);

        builder.Property(b => b.Note)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Note);

        builder.HasOne(b => b.Patient)
            .WithMany(b => b.Appointments)
            .HasForeignKey(b => b.PatientId);

        builder.HasOne(b => b.Doctor)
            .WithMany(b => b.Appointments)
            .HasForeignKey(b => b.DoctorId);
    }
}
