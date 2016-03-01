using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Remove
{
    public class RemoveLocationRequestHelper
                        : RemoveReferenceDataRequestBuilder<Location,
                                                            RemoveLocationRequest
                                                           >
    {
        public RemoveLocationRequestHelper(IEntityRepository<Location> the_repository)
            : base(the_repository) { }
    }
}