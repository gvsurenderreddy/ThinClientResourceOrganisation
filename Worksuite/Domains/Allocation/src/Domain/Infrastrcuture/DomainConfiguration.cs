using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Allocation.Infrastrcuture {

    public class DomainConfiguration 
                    : IDependencyConfiguration {

        public void configure 
                        ( IKernel kernel
                        , Func<IContext, object>  scope ) {

            AssemblyConfiguration.register_assemblies_binding_in_kernel
                                    ( GetType(  ).Assembly
                                    , kernel
                                    , scope );
        }


        public static void apply_to
                            ( IKernel kernel
                            , Func<IContext, object> scope ) {

            var domain_configuration = new DomainConfiguration();

            domain_configuration.configure( kernel, scope );
        }
    }
}