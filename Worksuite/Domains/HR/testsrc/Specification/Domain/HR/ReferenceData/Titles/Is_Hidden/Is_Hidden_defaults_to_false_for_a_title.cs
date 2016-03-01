using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Is_Hidden {

    [TestClass]
    public class Is_Hidden_for_a_Title_defaults_to_false_for_a_title
                    : Is_Hidden_defaults_to_false<CreateTitleRequest,GetCreateTitleRequestResponse,IGetCreateTitleRequest> {}

}