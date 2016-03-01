using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.eventHandlers.created
{
    [TestClass]
    public class employee_created_event_will : Specification<SupplyShortagesTestBootstrap>
    {
        [TestMethod]
        public void create_one_employee_supply_shortage( )
        {
            // Arrange
            test_setup( );

            var created_event = fixture.create_event( );

            // Act
            fixture.event_handler.handle( created_event );

            // Assert
            Assert.AreEqual( 1, fixture.repository.Count( ) );
        }

        [TestMethod]
        public void create_multiple_employee_supply_shortage()
        {
            // Arrange
            test_setup();

            var created_event1 = fixture.create_event( );
            var created_event2 = fixture.create_event( );
            var created_event3 = fixture.create_event( );

            // Act
            fixture.event_handler.handle( created_event1 );
            fixture.event_handler.handle( created_event2 );
            fixture.event_handler.handle( created_event3 );

            // Assert
            Assert.AreEqual( 3, fixture.repository.Count( ) );
        }

        [TestMethod]
        public void create_correct_employee_supply_shortage_entity()
        {
            // Arrange
            test_setup();

            var created_event1 = fixture.create_event( );
            var created_event2 = fixture.create_event( );
            var created_event3 = fixture.create_event( );

            // Act
            fixture.event_handler.handle( created_event1 );
            fixture.event_handler.handle( created_event2 );
            fixture.event_handler.handle( created_event3 );

            // Assert
            Assert.AreEqual( created_event2.employee_id, fixture.repository.Single(e => e.employee_id == created_event2.employee_id).employee_id );
        }

        public void test_setup( )
        {
            fixture = new EmployeeCreatedFixture( );
        }

        private EmployeeCreatedFixture fixture;
    }
}
