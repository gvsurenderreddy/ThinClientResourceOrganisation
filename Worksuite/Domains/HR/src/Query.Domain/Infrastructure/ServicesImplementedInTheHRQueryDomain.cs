using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Query.Infrastructure
{
    public class ServicesImplementedInTheHRQueryDomain
                  : IDependencyConfiguration
    {

        public void configure
                     (IKernel kernel
                     , Func<IContext, object> scope)
        {

            var all_dependency_configurations_define_in_HR_Query_domain = new AssemblyConfiguration(GetType().Assembly);

            all_dependency_configurations_define_in_HR_Query_domain
             .configure(kernel, scope);
        }


        public static void apply_to
                            (IKernel kernel
                            , Func<IContext, object> scope)
        {

            (new ServicesImplementedInTheHRQueryDomain())
                .configure(kernel, scope);

        }
    }
}
