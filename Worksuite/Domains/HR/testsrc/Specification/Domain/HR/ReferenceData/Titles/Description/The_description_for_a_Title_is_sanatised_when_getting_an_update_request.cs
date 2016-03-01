using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Description {

    [TestClass]
    public class The_description_for_a_Title_is_sanatised_when_getting_an_update_request
            : The_description_is_sanatised_when_getting_an_update_request<Title,UpdateTitleRequest,GetUpdateTitleRequestResponse,IGetUpdateTitleRequest> {}


}