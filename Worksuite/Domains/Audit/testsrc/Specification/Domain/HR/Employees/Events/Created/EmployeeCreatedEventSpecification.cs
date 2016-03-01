using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.HR.Employees.Events;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created {

    /// <summary>
    ///     Base specification for test that are for an <see cref="EmployeeCreatedEvent"/>.  It has 
    /// a <see cref="EmployeeCreatedEvent"/> fixture property that is reset before each test.
    /// </summary>
    public abstract class EmployeeCreatedEventSpecification 
                            : AuditSpecification {

        public EmployeeCreatedFixture fixture;

        protected override void test_setup () {
                base.test_setup();
            
                fixture = new EmployeeCreatedFixture();
        }

    }

}