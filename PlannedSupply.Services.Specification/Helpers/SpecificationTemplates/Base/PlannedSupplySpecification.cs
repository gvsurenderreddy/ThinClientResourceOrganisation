using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.PlannedSupply.Services.Infrastructure;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base
{
    // to do: rename to ASpecification

    /// <summary>
    ///     Base class for all specifications set the scope for the 
    ///         dependency injection to be for each test (i.e TestContext)
    /// </summary>
    /// <remaks>
    ///     This is needed because in VS2012 once we reached about sixteen 
    ///         hundred tests the MSTest test runner was re-using threads which 
    ///         was the scope that we were using for unit testing.  This was causing
    ///         spurious errors in 
    /// </remaks>
    [TestClass]
    public class PlannedSupplySpecification
                        : global::WorkSuite.Library.Service.Specification.Helpers.Specifications.Specification
    {
        protected override void configure_once_before_each_test_is_run( IKernel kernel,
                                                            Func< IContext, object > scope
                                                          )
        {
            _specification_configuration.configure( kernel, scope );
        }

        protected override void configure_once_before_all_tests_are_run(   IKernel kernel,
                                                    Func< IContext, object > scope
                                                )
        {
            PlannedSupply.Infrastructure.DomainConfiguration.apply_to( kernel, scope );
        }

        private static readonly PlannedSupplyUnitTestDependencyConfiguration _specification_configuration = new PlannedSupplyUnitTestDependencyConfiguration();
    }
}