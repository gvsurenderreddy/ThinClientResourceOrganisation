using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Helpers.Domain.Management.ServiceStatus;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Management.ServiceStates.Queries;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;

namespace WorkSuite.Configuration.Service.Domain.Management.ServiceStatus {

    [TestClass]
    public class The_service_status_is
                    : ConfigurationSpecification {

        // done: on line when there are no maintenance sessions.
        // done: in maintenance mode if any maintenance session exist

        [TestMethod]
        public void on_line_when_there_are_no_maintenance_session() {

            given_there_are_no_maintenace_sessions ();
            when_the_status_of_the_service_is_queried ();
            then_it_is_reported_as_online();
        }

        [TestMethod]
        public void in_maintenance_mode_if_any_maintenance_session_exist () {

            given_there_is_a_maintenance_session_in_progress ();
            when_the_status_of_the_service_is_queried();
            then_it_is_reported_as_in_maintenance_mode();
        }


        protected override void test_setup () {
            base.test_setup();
            service_status_helper = DependencyResolver.resolve<ServiceStatusHelper>();
            maintenance_session_helper = DependencyResolver.resolve<MaintenanceSessionHelper>();
            get_services_status = DependencyResolver.resolve<IGetServiceStatus>();

        }

        private void given_there_are_no_maintenace_sessions () {

            service_status_helper.clear_all_maintenace_sessions();
        }

        private void given_there_is_a_maintenance_session_in_progress () {
            maintenance_session_helper.add();
        }


        private void when_the_status_of_the_service_is_queried () {

            service_status = get_services_status.execute();
        }


        private void then_it_is_reported_as_online () {

            service_status.result.Should().BeOfType<ServiceIsOnline>();
            service_status.result.state.Should().Be( ServiceState.online );
        }

        private void then_it_is_reported_as_in_maintenance_mode () {

            service_status.result.Should().BeOfType<ServiceIsInMaintenanceMode>();
            service_status.result.state.Should().Be( ServiceState.maintenance_mode );
        }

        private ServiceStatusHelper service_status_helper;
        private MaintenanceSessionHelper maintenance_session_helper;
        private IGetServiceStatus get_services_status;
        private Configuration_ServiceStatusResponse service_status;
    }
}