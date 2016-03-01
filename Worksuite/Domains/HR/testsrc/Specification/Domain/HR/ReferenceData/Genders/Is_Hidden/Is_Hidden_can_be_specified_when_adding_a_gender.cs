using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Is_Hidden {

    [TestClass]
    public class Is_Hidden_can_be_specified_when_adding_a_gender 
                    : Is_Hidden_can_be_specified_when_adding_a_new_entry<Gender,CreateGenderRequest,CreateGenderResponse,ICreateGender,NewGenderFixture> {}

}