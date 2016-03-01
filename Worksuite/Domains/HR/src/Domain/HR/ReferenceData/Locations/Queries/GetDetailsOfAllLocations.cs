using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.Queries
{
    public class GetDetailsOfAllLocations
                    : GetDetailsOfAllReferenceData<Location, LocationDetails>,
                        IGetDetailsOfAllLocations
    {
        public GetDetailsOfAllLocations(IQueryRepository<Location> the_repository)
            : base(the_repository) { }
    }
}