using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Description {

    [TestClass]
    public class A_description_for_a_Title_is_mandatory_on_create
                    : A_description_is_mandatory_on_create<Title,CreateTitleRequest, CreateTitleResponse,ICreateTitle,NewTitleFixture> {}
}