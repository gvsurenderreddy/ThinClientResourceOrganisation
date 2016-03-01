using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Infrastructure;
using WTS.WorkSuite.HR.Services.Infrastructure;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base
{
    public class HRTestBootstrap : ITestBootstrap
    {
        public void setup_before_all_tests(object context)
        {
            DomainConfiguration.apply_to(
                DependencyResolver.kernel,
                m => context
            );
        }

        public void setup_before_each_test(object context)
        {
            specification_configuration.configure(
                DependencyResolver.kernel,
                m => context
            );
        }

        private readonly HRUnitTestDependencyConfiguration specification_configuration = new HRUnitTestDependencyConfiguration();
    }
}
