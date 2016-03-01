using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.GetById;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Management.MaintenanceSessions.GetById {

    [TestClass]
    public class GetMaintenanceSessionById_will
                    : ConfigurationSpecification {

        // done: returns the details of the specified maintenance session
        // done: returns a null maintenance session details if the session does not exist
        // done: response is set to has error if the session does not exist

        [TestMethod]
        public void returns_the_details_of_the_specified_maintenance_session () {
            var maintenance_session = helper.add().entity;
            var response = query.execute( new MaintenanceSessionIdentity { maintenance_session_id = maintenance_session.id } );

            response.has_errors.Should().BeFalse();
            response.result.maintenance_session_id.Should().Be( maintenance_session.id );
        }

        [TestMethod]
        public void returns_a_null_maintenance_session_details_if_the_session_does_not_exist () 
        {
            var response = query.execute( new MaintenanceSessionIdentity { maintenance_session_id = 52 });

            response.result.Should().NotBeNull();
            response.result.maintenance_session_id.Should().Be( -1 );
        }

        [TestMethod]
        public void response_is_set_to_has_error_if_the_session_does_not_exist () {
            var response = query.execute(new MaintenanceSessionIdentity { maintenance_session_id = 52 });

            response.has_errors.Should().BeTrue();
        }


        protected override void test_setup () {
            base.test_setup();
            helper = DependencyResolver.resolve<MaintenanceSessionHelper>();
            query = DependencyResolver.resolve<IGetMaintenanceSessionById>();            
        }

        private MaintenanceSessionHelper helper;
        private IGetMaintenanceSessionById query;       
    }
}