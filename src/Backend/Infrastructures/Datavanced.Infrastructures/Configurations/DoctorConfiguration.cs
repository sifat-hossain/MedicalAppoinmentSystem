namespace Datavanced.Infrastructures.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable(nameof(Doctor), b => b.IsTemporal());

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(b => b.Phone)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Number);

        builder.Property(b => b.Gender)
            .IsRequired();

        builder.Property(b => b.Address)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Address);

        builder.Property(b => b.Email)
            .HasMaxLength(Constants.FieldSize.Email);

        builder.Property(b => b.Degree)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Description);

        builder.Property(b => b.Designation)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Description);

    }
}
