using System;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Infrastructure.DependencyConfiguration {


    public class RouteConfiguration 
                    : ADependencyConfiguration  {

        public override void configure 
                                ( IKernel kernel, Func<IContext, object> scope ) {
             
            // Tell ninject to register all route configurations in the assembly
            kernel.Bind( x => x.FromThisAssembly()
                              .SelectAllClasses()
                              .InheritedFrom<INamedRouteDefinition>()
                              .BindAllInterfaces() );
        }

    }

}