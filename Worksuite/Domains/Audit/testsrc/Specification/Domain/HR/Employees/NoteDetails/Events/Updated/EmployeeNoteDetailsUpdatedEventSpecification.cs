using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.NoteDetails.Events.Updated
{
    public class EmployeeNoteDetailsUpdatedEventSpecification
                        : AuditSpecification
    {
        public EmployeeNoteDetailsUpdatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeNoteDetailsUpdatedEventFixture();
        }
    }
}