using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.DocumentStore;
using WTS.WorkSuite.HR.DocumentStore.Documents.New;
using WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Fields.Name
{
    public class does_not_have_leading_and_trailing_whitespace
    {
        [TestClass]
        public class verify_on_create
                        : TextFieldHasLeadingAndTrailingWhitespaceStrippedSpecification<NewDocumentRequest, NewDocumentResponse, NewDocumentFixture, Document>
        {

            public verify_on_create()
                : base((request) => request.name
                       , (value, request) => request.name = value
                       , (entity) => entity.name) { }
        }
    }
}
