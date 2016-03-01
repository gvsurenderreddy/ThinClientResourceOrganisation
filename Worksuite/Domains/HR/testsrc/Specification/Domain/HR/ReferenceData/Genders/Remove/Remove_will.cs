using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Remove {

    [TestClass]
    public class Remove_will 
                    : CommandCommitedChangesSpecification<RemoveGenderRequest,RemoveGenderResponse, RemoveGenderFixture> {}

}