using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.NoteDetails.Events.Removed
{
    public class EmployeeNoteDetailsRemovedEventSpecification
                        : AuditSpecification
    {
        public EmployeeNoteDetailsRemovedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeNoteDetailsRemovedEventFixture();
        }
    }
}