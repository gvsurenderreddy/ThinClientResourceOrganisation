using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Description {

    [TestClass]
    public class A_description_can_be_specified_when_adding_a_gender 
                    : A_description_can_be_specified_when_adding_a_new_entry<Gender,CreateGenderRequest,CreateGenderResponse,ICreateGender,NewGenderFixture> {}

}