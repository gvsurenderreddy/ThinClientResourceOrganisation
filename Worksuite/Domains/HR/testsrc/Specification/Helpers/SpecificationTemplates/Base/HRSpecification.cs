using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WTS.WorkSuite.HR.Services.Infrastructure;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base {


    // to do: rename to ASpecification

    /// <summary>
    ///     Base class for all specifications set the scope for the 
    /// dependency injection to be for each test (i.e TestContext)
    /// </summary>
    /// <remaks>
    ///     This is needed because in VS2012 once we reached about sixteen 
    /// hundred tests the MSTest test runner was re-using threads which 
    /// was the scope that we were using for unit testing.  This was causing
    /// spurious errors in 
    /// </remaks>
    [TestClass]
    public class HRSpecification 
                            : Specification {


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