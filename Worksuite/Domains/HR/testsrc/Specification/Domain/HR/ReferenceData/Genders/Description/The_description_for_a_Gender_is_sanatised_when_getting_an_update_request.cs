using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Description {

    [TestClass]
    public class The_description_for_a_Gender_is_sanatised_when_getting_an_update_request
            : The_description_is_sanatised_when_getting_an_update_request<Gender,UpdateGenderRequest,GetUpdateGenderRequestResponse,IGetUpdateGenderRequest> {}


}