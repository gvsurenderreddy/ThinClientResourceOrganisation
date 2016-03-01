using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Edit
{
    [TestClass]
    public class UpdateQualification_will
                    :   CommandCommitedChangesSpecification<    UpdateQualificationRequest,
                                                                UpdateQualificationResponse,
                                                                UpdateQualificationFixture
                                                           > {}

    [TestClass]
    public class command_will : ReferenceDataUpdatedEventSpecification<Qualification,
                                                                        UpdateQualificationRequest,
                                                                        UpdateQualificationResponse,
                                                                        IUpdateQualification,
                                                                        QualificationUpdatedEvent,
                                                                        UpdateQualificationEventFixture>
    {

    }
}
