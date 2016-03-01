using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Locations;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Queries.GetDetailsOfAllLocations
{
    [TestClass]
    public class Return_all_locations
                    : Returns_all_entries<Location,
                                          LocationBuilder,
                                          LocationDetails,
                                          GetDetailsOfAllLocationsFixture
                                         > { }
}