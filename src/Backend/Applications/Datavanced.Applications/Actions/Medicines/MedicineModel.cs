using Datavanced.Applications.Actions.Medicines.Push;

namespace Datavanced.Applications.Actions.Medicines;

public class MedicineModel : BaseModel
{
    public string Name { get; set; }
    public string GenericName { get; set; }
    public string Description { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpiredDate { get; set; }

    public static MedicineModel Create(Medicine entity)
    {
        return new MedicineModel
        {
            Id = entity.Id,
            Name = entity.Name,
            GenericName = entity.GenericName,
            Description = entity.Description,
            ProductionDate = entity.ProductionDate,
            ExpiredDate = entity.ExpiredDate,
            IsDeleted = entity.IsDeleted,
        };
    }

    public static MedicineModel CreateFromCommand(PushMedicineCommand command)
    {
        return new MedicineModel
        {
            Id = command.Id,
            Name = command.Name,
            GenericName = command.GenericName,
            Description = command.Description,
            ProductionDate = command.ProductionDate,
            ExpiredDate = command.ExpiredDate,
            IsDeleted = command.IsDeleted,
        };
    }
}