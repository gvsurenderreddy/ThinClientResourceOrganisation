using System.Collections.Generic;
using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.NamedRouteMetadataRepository
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Bind<INamedRouteMetadataRepository>()
                    .To<NamedRouteMetadataRepository>().InSingletonScope();

            kernel
                .Bind<IEnumerable<INamedRouteDefinition>>()
                .ToMethod(context => context.Kernel.GetAll<INamedRouteDefinition>());
        }
    }

}