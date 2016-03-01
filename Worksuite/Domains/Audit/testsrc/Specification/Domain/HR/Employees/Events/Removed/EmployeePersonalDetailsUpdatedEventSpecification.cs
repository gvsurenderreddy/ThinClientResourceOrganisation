using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Removed {


    public class EmployeeRemovedEventSpecification 
                    : AuditSpecification {


        public EmployeeRemovedEventFixture fixture { get; private set; }


        protected override void test_setup () {
            base.test_setup();

            fixture = new EmployeeRemovedEventFixture();
        }

    }
}