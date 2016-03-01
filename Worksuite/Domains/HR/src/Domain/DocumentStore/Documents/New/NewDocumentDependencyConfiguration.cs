using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.New
{
    public class NewDocumentDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetNewDocumentRequest>()
                .To<GetNewDocumentRequest>()
                ;

            kernel
                .Bind<INewDocument>()
                .To<NewDocument>()
                ;


            kernel
               .Bind<INewDocumentValidator>()
               .To<NewDocumentValidator>()
               ;

            kernel
             .Bind<ICanCreateDocument>()
             .To<CanCreateDocument>()
             ;
        }
    }
}