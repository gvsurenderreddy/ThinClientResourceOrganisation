using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.CodeStrutures.Creational;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.Library.Ninject.Factory;

namespace WTS.WorkSuite.PlannedSupply.Services.Infrastructure
{
    /// <summary>
    ///     Configures all the unit test specific Dependency injection bindings
    /// </summary>
    
    public class PlannedSupplyUnitTestDependencyConfiguration
                        : IDependencyConfiguration
    {
        /// <summary>
        ///     Load all the configurations in this ass
        /// </summary>
        /// <param name="kernel">
        ///     The kernel to be configured
        /// </param>
        /// <param name="scope">
        ///     The scope to use for any scope sensitive configurations.
        /// </param>
        
        public void configure(  IKernel kernel,
                                Func< IContext, object > scope
                             )
        {
            var configurator = new AssemblyConfiguration( GetType().Assembly );

            configurator.configure( kernel, scope );

            kernel
                .Rebind<    IUnitOfWork,
                            FakeUnitOfWork
                       > ()
                .To< FakeUnitOfWork > ()
                .InScope( scope )
                ;

            kernel
                .Rebind( typeof(IEventPublisher<>)
                       , typeof(FakeEventPublisher<>))
                .To( typeof(FakeEventPublisher<>) )
                .InScope( scope )
                ;


            kernel.Rebind(typeof(IFactory<>))
                    .To(typeof(NinjectDependencyFactory<>))
                    .InScope(scope);

            kernel.Rebind<IContext>()
                    .ToMethod(c => c.Request.ParentContext)
                    .InScope(scope);

        }
    }
}