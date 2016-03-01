using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.NoteDetails.Events.Created
{
    public class EmployeeNoteDetailsCreatedEventSpecification
                        : AuditSpecification
    {
        public EmployeeNoteDetailsCreatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeNoteDetailsCreatedEventFixture();
        }
    }
}