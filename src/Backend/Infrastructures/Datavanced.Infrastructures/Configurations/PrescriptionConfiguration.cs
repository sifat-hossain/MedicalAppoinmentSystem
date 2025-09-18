namespace Datavanced.Infrastructures.Configurations;

public class Prescriptionfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.ToTable(nameof(Prescription), b => b.IsTemporal());

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.Dosage)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Description);

        builder.Property(b => b.StartDate)
            .IsRequired()
            .HasColumnType(Constants.Precision.DateTime);

        builder.Property(b => b.EndDate)
            .IsRequired()
            .HasColumnType(Constants.Precision.DateTime);

        builder.Property(b => b.Notes)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Note);

        builder.HasOne(b => b.Medicine)
            .WithMany(b => b.Prescriptions)
            .HasForeignKey(b => b.MedicineId);

        builder.HasOne(b => b.Appoitment)
            .WithMany(b => b.Prescriptions)
            .HasForeignKey(b => b.AppoitmentId);
    }
}
