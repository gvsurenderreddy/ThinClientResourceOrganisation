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
    public class A_description_for_a_Location_is_mandatory
    {
        [TestClass]
        public class On_create
                        : A_description_is_mandatory_on_create<Location,
                                                               CreateLocationRequest,
                                                               CreateLocationResponse,
                                                               ICreateLocation,
                                                               NewLocationFixture
                                                              > { }

        [TestClass]
        public class On_update
                        : A_description_is_mandatory_on_update<Location,
                                                               UpdateLocationRequest,
                                                               UpdateLocationResponse,
                                                               IUpdateLocation,
                                                               UpdateLocationFixture
                                                              > { }
    }
}