using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.New {


    [TestClass]
    public class NewTitle_will
                    : CommandCommitedChangesSpecification<CreateTitleRequest, CreateTitleResponse, NewTitleFixture> { }
}