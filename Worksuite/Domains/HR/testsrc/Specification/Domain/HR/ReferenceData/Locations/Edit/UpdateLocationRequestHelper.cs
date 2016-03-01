using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Edit
{
    public class UpdateLocationRequestHelper
                    : UpdateReferenceDataRequestBuilder<Location,
                                                        UpdateLocationRequest
                                                       >
    {
        public UpdateLocationRequestHelper(IEntityRepository<Location> the_repository)
            : base(the_repository) { }
    }
}