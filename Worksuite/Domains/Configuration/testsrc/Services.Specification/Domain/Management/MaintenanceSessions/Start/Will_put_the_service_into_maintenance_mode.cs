using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.Start;
using WorkSuite.Configuration.Service.Management.ServiceStates.Queries;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Management.MaintenanceSessions.Start {

    [TestClass]
    public class Will_put_the_service_into_maintenance_mode 
                    : ConfigurationSpecification {

        // Note - Strictly speaking these are not unit tests as I am testing interaction between the parts of the system.
        //        The reason for this is that the interaction is what I want to protect and how that is achieve I am not 
        //        as concerned about so long as it is achieving it.

        [TestMethod]
        public void starting_a_maintenace_session_puts_the_service_into_maintenance_mode () {
            
            start_maintenance_session.execute();

            get_service_status
                .execute(  )
                .result
                .Should().BeOfType<ServiceIsInMaintenanceMode>();
        }

        protected override void test_setup ( ) {
            base.test_setup( );

            start_maintenance_session = DependencyResolver.resolve<IStartMaintenanceSession>(  );
            get_service_status = DependencyResolver.resolve<IGetServiceStatus>();
        }

        IStartMaintenanceSession start_maintenance_session;
        IGetServiceStatus get_service_status;
    }

}