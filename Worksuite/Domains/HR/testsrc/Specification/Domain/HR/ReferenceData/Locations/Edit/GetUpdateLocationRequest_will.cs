using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Edit
{
    [TestClass]
    public class GetUpdateLocationRequest_will
                    : GetUpdateReferenceDataRequest_will<Location,
                                                         UpdateLocationRequest,
                                                         GetUpdateLocationRequestResponse,
                                                         IGetUpdateLocationRequest
                                                        > { }
}