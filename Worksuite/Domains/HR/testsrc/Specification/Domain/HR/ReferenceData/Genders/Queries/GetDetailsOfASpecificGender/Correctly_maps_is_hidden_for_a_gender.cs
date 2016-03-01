using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Genders;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Queries.GetDetailsOfASpecificGender {

    [TestClass]
    public class Correctly_maps_is_hidden_for_a_gender
                    : Correctly_maps_is_hidden<Gender,GenderBuilder,GenderDetails,GetDetailsOfASpecificGenderFixture>{}
}