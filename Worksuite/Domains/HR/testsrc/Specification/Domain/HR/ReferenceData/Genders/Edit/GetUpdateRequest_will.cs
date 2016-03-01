using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Edit {

    [TestClass]
    public class GetUpdateGenderRequest_will
                    : GetUpdateReferenceDataRequest_will<Gender,UpdateGenderRequest,GetUpdateGenderRequestResponse,IGetUpdateGenderRequest> {  }

}