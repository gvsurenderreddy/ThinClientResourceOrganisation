using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Edit
{
    [TestClass]
    public class GetUpdateNationalityRequest_will
                        : GetUpdateReferenceDataRequest_will< Nationality, UpdateNationalityRequest, GetUpdateNationalityRequestResponse, IGetUpdateNationalityRequest > {}
}