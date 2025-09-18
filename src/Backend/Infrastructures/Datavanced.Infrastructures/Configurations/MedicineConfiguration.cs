namespace Datavanced.Infrastructures.Configurations;

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.ToTable(nameof(Medicine), b => b.IsTemporal());

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(b => b.GenericName)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(b => b.Description)
            .HasMaxLength(Constants.FieldSize.Description);
    }
}
