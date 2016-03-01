using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.End;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Management.MaintenanceSessions.End {

    [TestClass]
    public class Will_remove_the_maintenance_session
                    : ConfigurationSpecification {


        // done: removes the maintenance session
        // done: commits the removal of the maintenance session
        // done: does not throw an error if the session does not exist

        [TestMethod]
        public void removes_the_maintenance_session () {

            var maintenance_session_identity = create_session();

            end_maintenance_session.execute( maintenance_session_identity );

            session_does_not_exist( maintenance_session_identity );
        }

        [TestMethod]
        public void commits_the_removal_of_the_maintenance_session () {

            var maintenance_session_identity = create_session();

            end_maintenance_session.execute( maintenance_session_identity );

            unit_of_work.commit_was_called.Should().BeTrue();
        }


        [TestMethod]
        public void reports_confirmation_message_04_012_if_successful() {
            var maintenance_session_identity = create_session();

            var response = end_maintenance_session.execute(maintenance_session_identity);

            response.messages.Any( m => m.message == ConfirmationMessages.confirmation_04_0012 ).Should().BeTrue();
        }



        [TestMethod]
        public void does_not_throw_an_error_if_the_session_does_not_exist () {

            var response = end_maintenance_session.execute( new MaintenanceSessionDetails { maintenance_session_id = 32 });

            response.has_errors.Should().BeFalse();
        }


        protected override void test_setup () {
            base.test_setup();

            maintenance_session_helper = DependencyResolver.resolve<MaintenanceSessionHelper>();
            maintenance_session_repository = DependencyResolver.resolve<FakeMaintenanceSessionRepository>();
            end_maintenance_session = DependencyResolver.resolve<IEndMaintenanceSession>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private MaintenanceSessionIdentity create_session () {
            var maintenance_session = maintenance_session_helper
                                        .add()
                                        .entity;

            return new MaintenanceSessionDetails {
                maintenance_session_id = maintenance_session.id
            };
            
        }

        private void session_does_not_exist
                        ( MaintenanceSessionIdentity maintenance_session_identity ) {

            maintenance_session_repository
                .Entities
                .Any(ms => ms.id == maintenance_session_identity.maintenance_session_id)
                .Should()
                .BeFalse();
        }


        private MaintenanceSessionHelper maintenance_session_helper;
        private FakeMaintenanceSessionRepository maintenance_session_repository;
        private FakeUnitOfWork unit_of_work;
        private IEndMaintenanceSession end_maintenance_session;
    }
}
