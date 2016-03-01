using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.DocumentStore.Documents.New;
using WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Fields.Name
{
        public class A_name_is_mandatory
        {

            [TestClass]
            public class verify_on_create
                            : MandatoryTextFieldSpecification<NewDocumentRequest, NewDocumentResponse, NewDocumentFixture>
            {

                public verify_on_create()
                    : base((request, value) => request.name = value) { }
            }

        }
}
