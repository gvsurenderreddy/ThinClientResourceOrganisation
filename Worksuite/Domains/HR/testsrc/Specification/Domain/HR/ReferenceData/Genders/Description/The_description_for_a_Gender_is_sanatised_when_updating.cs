using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Description {

    [TestClass]
    public class The_description_for_a_Gender_is_sanatised_when_updating
        : The_description_is_sanatised_when_updating<Gender,UpdateGenderRequest,UpdateGenderResponse,IUpdateGender,UpdateGenderFixture> {}
}