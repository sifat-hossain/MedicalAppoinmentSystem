namespace Datavanced.Applications.Actions.Medicines.Pull.PullMedicines;

public class PullMedicinesHandler : IRequestHandler<PullMedicinesRequest, PushResponse<MedicineModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PullMedicinesHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<MedicineModel>> Handle(PullMedicinesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<Medicine> medicineQuery = await _coreDbContext.Medicine
                .Where(m => !m.IsDeleted)
                .AsNoTracking()
                .ToListAsync();

            if (medicineQuery.Count == 0)
            {
                return new PushResponse<MedicineModel>
                {
                    DidSucceed = true,
                    Models = new List<MedicineModel>()
                };
            }

            return new PushResponse<MedicineModel>
            {
                DidSucceed = true,
                Models = medicineQuery.Select(d => MedicineModel.Create(d)).ToList()
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