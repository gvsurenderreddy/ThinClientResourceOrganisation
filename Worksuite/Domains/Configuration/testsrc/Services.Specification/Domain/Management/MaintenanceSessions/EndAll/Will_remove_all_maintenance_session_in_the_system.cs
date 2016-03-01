using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Management.MaintenanceSessions.EndAll {

    [TestClass]
    public class Will_remove_all_maintenance_session_in_the_system
                    : ConfigurationSpecification {
         
        // done: removed all maintenance sessions
        // done: will commit the changes
        // done: is not an error if there are no maintenance sessions
        // done: reports confirmation message 04 010 if successful
        // done: reports an error if the request is not confirmed

        [TestMethod]
        public void removed_all_maintenance_sessions() {
            maintenance_session_helper.add();
            maintenance_session_helper.add();
            maintenance_session_helper.add();

            end_all_maintenance_sessions.execute( create_valid_request() );

            maintenance_session_helper.entities.Should().BeEmpty();
        }

        [TestMethod]
        public void will_commit_the_changes () {
            maintenance_session_helper.add();
            maintenance_session_helper.add();
            maintenance_session_helper.add();

            end_all_maintenance_sessions.execute( create_valid_request() );

            unit_of_work.commit_was_called.Should().BeTrue();
        }


        [TestMethod]
        public void is_not_an_error_if_there_are_no_maintenance_sessions () {

            end_all_maintenance_sessions.execute( create_valid_request() ).has_errors.Should().BeFalse();
        }

        [TestMethod]
        public void reports_confirmation_message_04_010_if_successful () {

            end_all_maintenance_sessions.execute( create_valid_request() ).messages.Any(rm => rm.message == ConfirmationMessages.confirmation_04_0010);
        }

        [TestMethod]
        public void reports_an_error_if_the_request_is_not_confirmed () {

            var response = end_all_maintenance_sessions.execute( new EndAllMaintenanceSessionsRequest { has_been_confirmed = false });

            response.has_errors.Should().BeTrue();
            response.messages.Should().Contain( rm => rm.field_name == "has_been_confirmed" && rm.message == ErrorMessages.error_00_0031 );
            response.messages.Should().Contain( rm => string.IsNullOrWhiteSpace( rm.field_name ) && rm.message == ErrorMessages.error_03_0010 );
        }

        protected override void test_setup() {
            base.test_setup();

            maintenance_session_helper = DependencyResolver.resolve<MaintenanceSessionHelper>();
            end_all_maintenance_sessions = DependencyResolver.resolve<IEndAllMaintenanceSessions>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private static EndAllMaintenanceSessionsRequest create_valid_request () {
            return new EndAllMaintenanceSessionsRequest {
                has_been_confirmed = true
            };
        }

        private MaintenanceSessionHelper maintenance_session_helper;
        private FakeUnitOfWork unit_of_work;
        private IEndAllMaintenanceSessions end_all_maintenance_sessions;
    }
}