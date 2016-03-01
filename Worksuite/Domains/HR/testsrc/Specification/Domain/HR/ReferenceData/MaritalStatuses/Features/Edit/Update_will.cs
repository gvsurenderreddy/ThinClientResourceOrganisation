using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Edit
{
    [TestClass]
    public class Update_will
                    :   CommandCommitedChangesSpecification< UpdateMaritalStatusRequest, UpdateMaritalStatusResponse, UpdateMaritalStatusFixture > {}

    [TestClass]
    public class command_will : ReferenceDataUpdatedEventSpecification<MaritalStatus,
                                                                        UpdateMaritalStatusRequest,
                                                                        UpdateMaritalStatusResponse,
                                                                        IUpdateMaritalStatus,
                                                                        MaritalStatusUpdatedEvent,
                                                                        UpdateMaritalStatusEventFixture>
    {

    }
}
