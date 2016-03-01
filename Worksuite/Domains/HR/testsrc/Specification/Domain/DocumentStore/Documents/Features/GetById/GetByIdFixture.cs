using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.DocumentStore;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.GetById;
using WTS.WorkSuite.HR.Services.Helpers.Domain.DocumentStore.Documents;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.GetById {

    public class GetByIdFixture : HRSpecification {

        protected override void test_setup()
        {
            base.test_setup();
            
            query = DependencyResolver.resolve<IGetDocumentById>();
            repository = DependencyResolver.resolve<IEntityRepository<Document>>();

        }

        protected DocumentBuilder add_document () {
            var builder = new DocumentBuilder(new Document());

            repository.add(builder.entity);

            return builder;
        }

        protected Response<DocumentDetails> execute_query(Document document)
        {

            return query.execute(new DocumentIdentity {  document_id = document.id });

        }

        protected IGetDocumentById query;
        protected IEntityRepository<Document> repository;
    }

}