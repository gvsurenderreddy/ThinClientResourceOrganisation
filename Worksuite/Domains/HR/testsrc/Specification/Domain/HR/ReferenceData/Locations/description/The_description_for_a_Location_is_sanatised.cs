using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.description
{
    public class The_description_for_a_Location_is_sanatised
    {
        [TestClass]
        public class When_creating
                        : The_description_is_sanatised_when_creating<Location,
                                                                     CreateLocationRequest,
                                                                     CreateLocationResponse,
                                                                     ICreateLocation,
                                                                     NewLocationFixture
                                                                    > { }

        [TestClass]
        public class When_updating
                        : The_description_is_sanatised_when_updating<Location,
                                                                     UpdateLocationRequest,
                                                                     UpdateLocationResponse,
                                                                     IUpdateLocation,
                                                                     UpdateLocationFixture
                                                                    > { }
    }
}