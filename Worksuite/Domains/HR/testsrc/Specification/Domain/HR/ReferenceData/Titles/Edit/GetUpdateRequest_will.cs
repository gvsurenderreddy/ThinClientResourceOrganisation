using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Edit {

    [TestClass]
    public class GetUpdateTitleRequest_will
                    : GetUpdateReferenceDataRequest_will<Title,UpdateTitleRequest,GetUpdateTitleRequestResponse,IGetUpdateTitleRequest> {  }

}