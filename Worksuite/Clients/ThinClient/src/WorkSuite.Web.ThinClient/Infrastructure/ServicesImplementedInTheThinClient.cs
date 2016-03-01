using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure
{
    public class ServicesImplementedInTheThinclient
                  : IDependencyConfiguration
    {

        public void configure
                     (IKernel kernel
                     , Func<IContext, object> scope)
        {

            var all_dependency_configurations_define_in_thin_client = new AssemblyConfiguration(GetType().Assembly);

            all_dependency_configurations_define_in_thin_client
             .configure(kernel, scope);
        }


        public static void apply_to
                            (IKernel kernel
                            , Func<IContext, object> scope)
        {

            (new ServicesImplementedInTheThinclient())
                .configure(kernel, scope);

        }
    }
}
