using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.Infrastructure {

    /// <summary>
    ///     Applies all the dependency configuration that have been defined in the Audit domain via 
    /// a <see cref="ADependencyConfiguration"/>to an Ninject kernel.
    /// </summary>
    public class DomainConfiguration 
                    : IDependencyConfiguration   {
        
        public void configure 
                        ( IKernel kernel
                        , Func<IContext,object> scope  ) {
            
            var all_dependency_configuration_defined_in_audit_domain = new AssemblyConfiguration( GetType(  ).Assembly );

            all_dependency_configuration_defined_in_audit_domain
                .configure( kernel, scope )
                ;
        }

        public static void apply_to
                            ( IKernel kernel
                            , Func<IContext, object> scope ) {

            var domain_configuration = new DomainConfiguration();

            domain_configuration.configure( kernel, scope );
        }

    }
}