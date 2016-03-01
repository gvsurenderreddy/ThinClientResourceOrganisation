using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.description
{
    [TestClass]
    public class A_description_can_be_specified_when_adding_a_location
                        : A_description_can_be_specified_when_adding_a_new_entry<Location,
                                                                                 CreateLocationRequest,
                                                                                 CreateLocationResponse,
                                                                                 ICreateLocation,
                                                                                 NewLocationFixture
                                                                                > { }
}