using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.DocumentStore.Documents.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.New
{
    public class NewDocument_will
    {
        [TestClass]
        public class NewDocument_will_commit_changes
                        : CommandCommitedChangesSpecification<NewDocumentRequest, NewDocumentResponse, NewDocumentFixture> { }
    }
}