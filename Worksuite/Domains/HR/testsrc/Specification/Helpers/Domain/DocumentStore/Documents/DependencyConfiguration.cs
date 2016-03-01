using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.DocumentStore;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.New;
using WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.New;
using WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.Remove;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.DocumentStore.Documents
{
    public class DependencyConfiguration : ADependencyConfiguration
    {

        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Rebind<IQueryRepository<Document>
                         , IEntityRepository<Document>
                         , FakeDocumentRepository>()
                .To<FakeDocumentRepository>()
                .InScope(x => scope)
                ;

            kernel
                .Rebind<IRequestHelper<NewDocumentRequest>
                       , NewDocumentRequestHelper>()
                .To<NewDocumentRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<DocumentIdentity>
                       , RemoveDocumentRequestHelper>()
                .To<RemoveDocumentRequestHelper>()
                ;


        }

    }
}