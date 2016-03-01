using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.GetCreateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.is_hidden
{
    [TestClass]
    public class Is_Hidden_for_a_location_defaults_to_false_for_a_location
                        : Is_Hidden_defaults_to_false<CreateLocationRequest,
                                                      GetCreateLocationRequestResponse,
                                                      IGetCreateLocationRequest
                                                     > { }
}