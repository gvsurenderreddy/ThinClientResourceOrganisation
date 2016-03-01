using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit
{
    public class GetUpdateLocationRequest
                    : GetUpdateReferenceDataRequest<Location, UpdateLocationRequest, GetUpdateLocationRequestResponse>,
                        IGetUpdateLocationRequest
    {
        public GetUpdateLocationRequest(IEntityRepository<Location> the_repository)
            : base(the_repository) { }
    }
}