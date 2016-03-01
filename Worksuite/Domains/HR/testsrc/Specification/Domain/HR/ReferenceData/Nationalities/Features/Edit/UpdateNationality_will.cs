using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Edit
{
    [TestClass]
    public class UpdateNationality_will
                        : CommandCommitedChangesSpecification< UpdateNationalityRequest, UpdateNationalityResponse, UpdateNationalityFixture > {}



    [TestClass]
    public class command_will : ReferenceDataUpdatedEventSpecification<Nationality,
                                                                        UpdateNationalityRequest,
                                                                        UpdateNationalityResponse,
                                                                        IUpdateNationality,
                                                                        NationalityUpdatedEvent,
                                                                        UpdateNationalityEventFixture>
    {

    }



}