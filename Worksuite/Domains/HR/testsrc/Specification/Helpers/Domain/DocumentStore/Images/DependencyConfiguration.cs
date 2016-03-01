using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.Persistence.Infrastructure;
using WTS.WorkSuite.Persistence.Domain.DocumentStore;
using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.Domain.DocumentStore.Images.Remove;
using WTS.WorkSuite.Service.Helpers.Framework.Request;

namespace WTS.WorkSuite.Service.Helpers.Domain.DocumentStore.Images
{
    public class DependencyConfiguration : ADependencyConfiguration
    {

        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Rebind<IQueryRepository<Image>, IEntityRepository<Image>, FakeImageRepository>()
                .To<FakeImageRepository>()
                .InScope(x => scope)
                ;


            kernel
                .Rebind<IRequestBuilder<ImageIdentity>
                       , RemoveRequestBuilder>()
                .To<RemoveRequestBuilder>()
                ;

        }
    }
}
