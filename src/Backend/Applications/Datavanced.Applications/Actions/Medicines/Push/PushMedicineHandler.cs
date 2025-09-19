namespace Datavanced.Applications.Actions.Medicines.Push;

public sealed class PushMedicineHandler : IRequestHandler<PushMedicineCommand, PushResponse<MedicineModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PushMedicineHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<MedicineModel>> Handle(PushMedicineCommand command, CancellationToken cancellationToken)
    {
        try
        {

            Medicine? medicine = await _coreDbContext.Medicine
                .SingleOrDefaultAsync(d => d.Id == command.Id && !d.IsDeleted, cancellationToken);

            if (medicine == null)
            {
                medicine = new Medicine
                {
                    Id = Guid.NewGuid(),
                };
                _coreDbContext.Medicine.Add(medicine);
            }
            medicine.Name = command.Name;
            medicine.ExpiredDate = command.ExpiredDate;
            medicine.ProductionDate = command.ProductionDate;
            medicine.IsDeleted = command.IsDeleted;
            medicine.Description = command.Description;
            medicine.GenericName = command.GenericName;

            await _coreDbContext.SaveChangesAsync(cancellationToken);

            return new PushResponse<MedicineModel>
            {
                DidSucceed = true,
                Model = MedicineModel.CreateFromCommand(command),
            };
        }
        catch (Exception ex)
        {

            return new PushResponse<MedicineModel>
            {
                DidSucceed = false,
                Message = string.Join(ex.Message, ex.InnerException?.Message)

            };
        }
    }
}