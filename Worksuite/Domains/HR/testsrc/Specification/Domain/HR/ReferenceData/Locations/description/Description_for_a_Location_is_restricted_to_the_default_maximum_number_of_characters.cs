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
    public class Description_for_a_Location_is_restricted_to_the_default_maximum_number_of_characters
    {
        [TestClass]
        public class Verify_on_create
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<Location,
                                                                                                          CreateLocationRequest,
                                                                                                          CreateLocationResponse,
                                                                                                          ICreateLocation,
                                                                                                          NewLocationFixture
                                                                                                         > { }

        [TestClass]
        public class Verify_on_update
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<Location,
                                                                                                          UpdateLocationRequest,
                                                                                                          UpdateLocationResponse,
                                                                                                          IUpdateLocation,
                                                                                                          UpdateLocationFixture
                                                                                                         > { }
    }
}