using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.Remove
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Bind<IRemoveDocument>()
                .To<RemoveDocument>()
                ;

            kernel
                .Bind<IRemoveManyDocuments>()
                .To<RemoveManyDocuments>()
                ;

            kernel
             .Bind<ICanRemoveDocument>()
             .To<CanRemoveDocument>()
             ;
        }
    }
}