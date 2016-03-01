using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.Start;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Management.MaintenanceSessions.Start {

    [TestClass]
    public class Will_create_a_new_maintenance_session 
                    : ConfigurationSpecification {

        [TestMethod]
        public void start_maintenance_session_adds_a_session_into_the_repository () {
            when_a_start_maintenance_session_request_is_made();
            then_a_new_maintenance_session_is_created();
        }

        [TestMethod]
        public void start_maintenance_session_commits_the_new_session() {
            when_a_start_maintenance_session_request_is_made();
            then_the_maintenance_session_is_commited();            
        }

        [TestMethod]
        public void start_maintenance_session_reports_confirmation_message_04_009_if_successful () {
            when_a_start_maintenance_session_request_is_made();
            then_the_maintenance_session_message_04_009_is_reported ();            
        }


        protected override void test_setup ( ) {            
            start_maintenance_session = DependencyResolver.resolve<IStartMaintenanceSession>(  );
            maintenance_session_repository = DependencyResolver.resolve<FakeMaintenanceSessionRepository>(  );
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>(  );
        }

        private void when_a_start_maintenance_session_request_is_made () {
            response = start_maintenance_session.execute();
        }

        private void then_a_new_maintenance_session_is_created ( ) {

            maintenance_session_repository.Entities.Any( ms => ms.id == response.result.maintenance_session_id ).Should(  ).BeTrue(  );
        }

        private void then_the_maintenance_session_is_commited () {
            unit_of_work.commit_was_called.Should(  ).BeTrue(  );
        }

        private void then_the_maintenance_session_message_04_009_is_reported () {
            response.messages.Any( m => m.message == ConfirmationMessages.confirmation_04_0009 );
        }

        private IStartMaintenanceSession start_maintenance_session;
        private FakeMaintenanceSessionRepository maintenance_session_repository;
        private FakeUnitOfWork unit_of_work;

        private StartMaintenanceSessionResponse response;
    }

}