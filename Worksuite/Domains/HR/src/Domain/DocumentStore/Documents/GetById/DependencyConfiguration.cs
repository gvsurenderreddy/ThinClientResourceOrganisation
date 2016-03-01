using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.GetById
{
    public class GetByIdDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
             .Bind<IGetDocumentById>()
             .To<GetDocumentById>()
             ;
        }
    }
}