using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Locations;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Queries.GetDetailsOfAllLocations
{
    public class GetDetailsOfAllLocationsFixture
                    : GetDetailsOfAllReferenceDataFixture<Location,
                                                          LocationDetails,
                                                          IGetDetailsOfAllLocations,
                                                          LocationBuilder,
                                                          FakeLocationRepository,
                                                          LocationHelper
                                                         >
    {
        public GetDetailsOfAllLocationsFixture(LocationHelper the_helper,
                                               IGetDetailsOfAllLocations the_query
                                              )
            : base(the_helper,
                   the_query
                  ) { }
    }
}