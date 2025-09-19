namespace Datavanced.Applications.Actions.Medicines.Push;

public sealed class PushMedicineCommand : BaseModel, IRequest<PushResponse<MedicineModel>>
{
    public string Name { get; set; }
    public string GenericName { get; set; }
    public string Description { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpiredDate { get; set; }
}