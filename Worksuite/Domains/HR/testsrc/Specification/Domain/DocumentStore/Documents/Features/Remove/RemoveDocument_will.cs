using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.DocumentStore.Documents;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.Remove
{
    [TestClass]
    public class RemoveDocument_will : CommandCommitedChangesSpecification<DocumentIdentity, RemoveDocumentResponse, RemoveDocumentFixture>
    {

            [TestMethod]
            public void remove_the_Document()
            {
                fixture.execute_command();

                Document_repository.Entities.Select(e => e.id == fixture.request.document_id).Should().BeEmpty();

            }

            [TestMethod]
            public void return_no_errors_if_the_entity_does_not_exist()
            {
                Document_repository.clear();

                fixture.execute_command();

                fixture.response.has_errors.Should().BeFalse();

            }


            protected override void test_setup()
            {
                base.test_setup();
                Document_repository = DependencyResolver.resolve<FakeDocumentRepository>();
            }

            private FakeDocumentRepository Document_repository;

        } 
}