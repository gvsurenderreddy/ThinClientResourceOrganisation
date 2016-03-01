using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WTS.WorkSuite.HR.Query.Infrastructure;

namespace WTS.WorkSuite.HR.Query.Helpers.SpecificationTemplates.Base
{
    public class HRQuerySpecification : Specification
    {
        protected override void configure_once_before_each_test_is_run(IKernel kernel, Func<IContext, object> scope)
        {
            hr_query_unit_test_dependency_configuration.configure(kernel, scope);
        }

        protected override void configure_once_before_all_tests_are_run(IKernel kernel, Func<IContext, object> scope)
        {
            ServicesImplementedInTheHRQueryDomain.apply_to(kernel, scope);
        }

        private static readonly HRQueryDomainTestDependencyConfiguration hr_query_unit_test_dependency_configuration = new HRQueryDomainTestDependencyConfiguration();
    }
}
