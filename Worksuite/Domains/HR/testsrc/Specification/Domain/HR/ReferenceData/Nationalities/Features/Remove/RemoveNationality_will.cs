using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Remove
{
    [TestClass]
    public class RemoveNationality_will
                        : CommandCommitedChangesSpecification< RemoveNationalityRequest, RemoveNationalityResponse, RemoveNationalityFixture > {}
}