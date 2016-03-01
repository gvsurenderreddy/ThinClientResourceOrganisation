using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.End;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.Start;
using WorkSuite.Configuration.Service.Management.ServiceStates.Queries;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;

namespace WorkSuite.Configuration.Service.Domain.Management.MaintenanceSessions.End {

    [TestClass]
    public class Will_affect_the_systems_status_by 
                    : ConfigurationSpecification {


        [TestMethod]
        public void taking_the_system_out_of_maintenance_mode_if_the_only_maintenance_session () {
            var maintenance_session = start_maintenance_session.execute();

            end_maintenance_session.execute( maintenance_session.result );

            get_service_status
                .execute()
                .result
                .Should()
                .BeOfType<ServiceIsOnline>();
        }

        [TestMethod]
        public void leaving_the_system_in_maintenance_mode_more_than_one_session_is_in_the_system () {
            var maintenance_session = start_maintenance_session.execute();
            start_maintenance_session.execute();

            end_maintenance_session.execute( maintenance_session.result );

            get_service_status
                .execute()
                .result
                .Should()
                .BeOfType<ServiceIsInMaintenanceMode>();
        }


        protected override void test_setup() {
            base.test_setup();

            start_maintenance_session = DependencyResolver.resolve<IStartMaintenanceSession>();
            end_maintenance_session = DependencyResolver.resolve<IEndMaintenanceSession>();
            get_service_status = DependencyResolver.resolve<IGetServiceStatus>();
        }

        private IStartMaintenanceSession start_maintenance_session;
        private IEndMaintenanceSession end_maintenance_session;
        private IGetServiceStatus get_service_status;
    }
}