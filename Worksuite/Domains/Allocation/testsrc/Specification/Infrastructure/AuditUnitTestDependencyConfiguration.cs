using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Allocation.Services.Infrastructure {


    public class AllocationUnitTestDependencyConfiguration 
                    : IDependencyConfiguration {

        public static void apply_to
                            ( IKernel kernel
                            , Func<IContext, object> scope ) {

            var domain_configuration = new AllocationUnitTestDependencyConfiguration();

            domain_configuration.configure( kernel, scope );
        }


        public void configure 
                        ( IKernel kernel
                        , Func<IContext, object> scope ) {

            var all_dependencies_in_assembly = new AssemblyConfiguration( GetType(  ).Assembly );

            all_dependencies_in_assembly.configure( kernel, scope );

            kernel
                .Rebind< IUnitOfWork
                       , FakeUnitOfWork>()
                .To<FakeUnitOfWork>()
                .InScope( scope )
                ;
        }
    }
}