using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.is_hidden
{
    [TestClass]
    public class Is_Hidden_can_be_specified_when_adding_a_location
                        : Is_Hidden_can_be_specified_when_adding_a_new_entry<Location,
                                                                             CreateLocationRequest,
                                                                             CreateLocationResponse,
                                                                             ICreateLocation,
                                                                             NewLocationFixture
                                                                            > { }
}