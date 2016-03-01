using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Edit
{
    [TestClass]
    public class GetUpdateMaritalStatusRequest_will
                    :   GetUpdateReferenceDataRequest_will< MaritalStatus, UpdateMaritalStatusRequest, GetUpdateMaritalStatusRequestResponse, IGetUpdateMaritalStatusRequest > {}
}
