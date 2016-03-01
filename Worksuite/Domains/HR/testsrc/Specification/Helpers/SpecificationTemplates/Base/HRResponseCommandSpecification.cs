using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.HR.Services.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base {


    /// <summary>
    ///     Specifications that execute against command that can be verified
    /// against the response from a command.
    /// </summary>
    /// <typeparam name="P">
    ///     The request expected from the command
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The response expected from the command
    /// </typeparam>
    /// <typeparam name="F">
    ///     The fixture for the specification. It must be a <see cref="IsAResponseCommandFixture{P,Q}" />
    /// </typeparam>
    public abstract class HRResponseCommandSpecification<P,Q,F>
                            : ResponseCommandSpecification<P, Q, F>
                    where Q : Response
                    where F : IsAResponseCommandFixture<P,Q> {
        
        protected override void configure_once_before_each_test_is_run
                                    ( IKernel kernel
                                    , Func<IContext, object> scope ) {

            specification_configuration.configure(kernel, scope);
        }

        protected override void configure_once_before_all_tests_are_run
                                    ( IKernel kernel
                                    , Func<IContext, object> scope ) {

            WTS.WorkSuite.HR.Infrastructure.DomainConfiguration.apply_to( kernel, scope );
        }

        private static readonly HRUnitTestDependencyConfiguration specification_configuration = new HRUnitTestDependencyConfiguration();
    }
}