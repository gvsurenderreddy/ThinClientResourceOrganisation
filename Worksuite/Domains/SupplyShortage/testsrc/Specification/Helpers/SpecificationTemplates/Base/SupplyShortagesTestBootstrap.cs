using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.SupplyShortage.Services.Infrastructure;

namespace WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base
{
    public class SupplyShortagesTestBootstrap : ITestBootstrap
    {

        public void setup_before_all_tests(object context)
        {
            SupplyShortage.Infrastructure.DomainConfiguration.apply_to(
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

        private readonly SupplyShortagesUnitTestDependencyConfiguration specification_configuration = new SupplyShortagesUnitTestDependencyConfiguration();

    }
}
