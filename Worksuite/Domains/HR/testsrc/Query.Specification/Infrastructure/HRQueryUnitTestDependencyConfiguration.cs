using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Query.Infrastructure
{
    public class HRQueryDomainTestDependencyConfiguration : IDependencyConfiguration
    {

        public void configure
                        (IKernel kernel
                        , Func<IContext, object> scope)
        {

            var all_dependencies_in_assembly = new AssemblyConfiguration(GetType().Assembly);

            all_dependencies_in_assembly.configure(kernel, scope);

            kernel
                .Rebind<IUnitOfWork
                       , FakeUnitOfWork>()
                .To<FakeUnitOfWork>()
                .InScope(scope)
                ;

        }
    }
}
