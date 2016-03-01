using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Is_Hidden {

    [TestClass]
    public class Is_Hidden_can_be_specified_when_adding_a_title 
                    : Is_Hidden_can_be_specified_when_adding_a_new_entry<Title,CreateTitleRequest,CreateTitleResponse,ICreateTitle,NewTitleFixture> {}

}