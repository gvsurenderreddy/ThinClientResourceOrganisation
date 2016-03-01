using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New.Create;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.New {


    [TestClass]
    public class NewGender_will
                    : CommandCommitedChangesSpecification<CreateGenderRequest, CreateGenderResponse, NewGenderFixture> { }
}