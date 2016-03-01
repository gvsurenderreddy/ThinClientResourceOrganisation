using System.Collections.Generic;
using System.Linq;
using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.Remove
{
    public class RemoveManyDocuments : IRemoveManyDocuments
    {
        public RemoveManyDocuments(IUnitOfWork theUnitOfWork
                              , IEntityRepository<Document> theRepository)
        {

            unit_of_work = Guard.IsNotNull(theUnitOfWork, "the_unit_of_work");
            repository = Guard.IsNotNull(theRepository, "the_repository");
        }

        public RemoveManyDocumentsResponse execute(IEnumerable<DocumentIdentity> the_request)
        {


            return this.set_request(the_request)
                .find_documents()
                .remove_document()
                .commit()
                .build_response();

        }

        private RemoveManyDocuments set_request(IEnumerable<DocumentIdentity> the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder.set_response(new List<DocumentIdentity>
            {
                new DocumentIdentity
                {
                    document_id = Null.Id
                }
            });

            return this;
        }


        private RemoveManyDocuments find_documents()
        {
            Guard.IsNotNull(request, "the_request");

            foreach (var document in request)
            {
                var result = repository
                                .Entities
                                .SingleOrDefault(e => e.id == document.document_id)
                                ;

                documents.Add(result);
            }

            return this;
        }


        private RemoveManyDocuments remove_document()
        {
            foreach (var document in documents)
            {
                repository.remove(document);
            }

            return this;
        }

        private RemoveManyDocuments commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private RemoveManyDocumentsResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
                return response_builder.build();
            }

            response_builder.add_message(ValidationMessages.remove_was_successfull);
            return response_builder.build();
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<Document> repository;
        private readonly ResponseBuilder<IEnumerable<DocumentIdentity>, RemoveManyDocumentsResponse> response_builder = new ResponseBuilder<IEnumerable<DocumentIdentity>, RemoveManyDocumentsResponse>();

        private IEnumerable<DocumentIdentity> request;
        private readonly List<Document> documents = new List<Document>();

    }
}