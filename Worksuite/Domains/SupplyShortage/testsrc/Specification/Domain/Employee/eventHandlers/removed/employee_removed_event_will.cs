using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.eventHandlers.removed
{
    [TestClass]
    public class employee_removed_event_will : Specification<SupplyShortagesTestBootstrap>
    {
        [TestMethod]
        public void remove_employee_supply_shortage( )
        {
            // Arrange
            test_setup( );
            var new_employee_id = fixture.add_employee_to_repository( );
            var employee_remove_event = fixture.create_remove_event_for_employee_id( new_employee_id );

            // Act
            fixture.event_handler.handle( employee_remove_event );

            // Assert
            Assert.AreEqual( 0, fixture.repository.Count( ) );
        }

        [TestMethod]
        public void remove_one_employee_supply_shortage_from_3_in_repository( )
        {
            // Arrange (3 employees and we will remove the second one added)
            test_setup( );

            fixture.add_employee_to_repository( );
            var employee_to_remove = fixture.add_employee_to_repository( );
            fixture.add_employee_to_repository( );

            var employee_remove_event = fixture.create_remove_event_for_employee_id( employee_to_remove );

            // Act
            fixture.event_handler.handle( employee_remove_event );

            // Assert
            Assert.AreEqual( 2, fixture.repository.Count( ) );
        }

        public void test_setup( )
        {
            fixture = new EmployeeRemovedFixture( );
        }

        private EmployeeRemovedFixture fixture;
    }
}
