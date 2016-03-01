using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Allocation.Infrastrcuture;
using WTS.WorkSuite.Allocation.Services.Infrastructure;

namespace WTS.WorkSuite.Allocation.Services.Helpers.SpecificationTemplates {

    /// <summary>
    ///     Bootstrapper that setup up a test run for allocation
    /// </summary>
    public class AllocatedSupplyTestBootstrapper
                    : TestBootstrapper {

        protected override void initialise_for_test_run                                     
                                    ( IKernel kernel
                                    , Func<IContext, object> scope ) {

            DomainConfiguration.apply_to( kernel, scope );
            AllocationUnitTestDependencyConfiguration.apply_to( kernel, scope );
        }
    }
}