using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Fields.Description
{
    [TestClass]
    public class A_description_for_a_marital_status_is_mandatory_on_create
                            :   A_description_is_mandatory_on_create<MaritalStatus, CreateMaritalStatusRequest, CreateMaritalStatusResponse, ICreateMaritalStatus, NewMaritalStatusFixture> {}
}
