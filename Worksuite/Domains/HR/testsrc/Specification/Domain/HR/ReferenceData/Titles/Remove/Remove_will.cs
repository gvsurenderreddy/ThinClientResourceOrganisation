using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Remove {

    [TestClass]
    public class Remove_will 
                    : CommandCommitedChangesSpecification<RemoveTitleRequest,RemoveTitleResponse, RemoveTitleFixture> {}

}