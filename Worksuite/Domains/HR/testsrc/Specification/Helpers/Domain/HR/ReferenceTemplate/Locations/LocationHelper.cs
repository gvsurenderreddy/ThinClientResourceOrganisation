using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Locations
{
    public class LocationHelper
                    : ReferenceDataHelper<Location,
                                          LocationBuilder,
                                          FakeLocationRepository
                                         > { }
}