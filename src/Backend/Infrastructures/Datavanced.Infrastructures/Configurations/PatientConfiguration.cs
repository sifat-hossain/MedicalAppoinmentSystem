namespace Datavanced.Infrastructures.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable(nameof(Patient), b => b.IsTemporal());

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(b => b.Phone)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Number);

        builder.Property(b => b.Age)
            .HasMaxLength(Constants.FieldSize.Age);

        builder.Property(b => b.Address)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Address);
    }
}
