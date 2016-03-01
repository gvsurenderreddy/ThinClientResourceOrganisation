using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WTS.WorkSuite.Web.ThinClient.Infrastructure;

namespace WTS.WorkSuite.Web.ThinClient.Helpers.SpecificationTemplates.Base
{
    public class ThinClientSpecification : Specification
    {
        protected override void configure_once_before_each_test_is_run(IKernel kernel, Func<IContext, object> scope)
        {
            thin_client_unit_test_dependency_configuration.configure(kernel, scope);
        }

        protected override void configure_once_before_all_tests_are_run(IKernel kernel, Func<IContext, object> scope)
        {
            ServicesImplementedInTheThinclient.apply_to(kernel, scope);
        }

        private static readonly ThinClientUnitTestDependencyConfiguration thin_client_unit_test_dependency_configuration = new ThinClientUnitTestDependencyConfiguration();
    }
}
