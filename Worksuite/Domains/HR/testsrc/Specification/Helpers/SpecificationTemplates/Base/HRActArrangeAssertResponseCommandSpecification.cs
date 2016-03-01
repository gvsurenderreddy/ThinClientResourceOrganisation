using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.ActArangeAssert;
using WTS.WorkSuite.HR.Services.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base {

    /// <summary>
    ///     HR specific Act/Arrange/Assert specification.  The Fake persistence layer is 
    /// reset in the Ioc before each test is run to ensure that any data from a previous test
    /// is wiped.
    /// </summary>
    /// <typeparam name="P">
    ///     The type of the request that the execute method of the command expects.
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The type of the response that is returned from the execute method of the command.
    /// </typeparam>
    /// <typeparam name="F">
    ///     Fixture that will execute the command.
    /// </typeparam>
    public abstract class HRActArrangeAssertResponseCommandSpecification<P,Q,F>
                                    : ActArrangeAssertResponseCommandSpecification<P, Q, F> 
                            where Q : Response 
                            where F : IsAResponseCommandFixture<P,Q> {

        protected override void configure_once_before_each_test_is_run
                                    ( IKernel kernel
                                    , Func<IContext, object> scope) {

            dependency_configuration.configure
                                        ( kernel
                                        , scope );
        }


        protected override void configure_once_before_all_tests_are_run
                                    ( IKernel kernel
                                    , Func<IContext, object> scope) {

            WTS.WorkSuite.HR.Infrastructure.DomainConfiguration.apply_to( kernel, scope );
        }

        private static readonly HRUnitTestDependencyConfiguration dependency_configuration = new HRUnitTestDependencyConfiguration();
    } 
}