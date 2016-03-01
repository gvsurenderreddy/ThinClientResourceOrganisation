using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Management.MaintenanceSessions.EndAll.Request.Fields.han_been_confirmed {

    [TestClass]
    public class defaults_to_false
                    : ConfigurationSpecification {

        [TestMethod]
        public void EndAllMaintenanceSessionsRequest_has_been_confirmed_defaults_to_false() {
            var command = DependencyResolver.resolve<IGetEndAllMaintenanceSessionsRequest>(  ) ;

            command.execute(  ).has_been_confirmed.Should().BeFalse(  );
        }
    }
}