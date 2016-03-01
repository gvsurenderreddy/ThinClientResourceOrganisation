using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.NoteDetails
{
    public class ModelBuilder
                    : ModelConfiguration<EmployeeNoteDetailsAuditRecord>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeeNoteDetailsAuditRecord", schema));
        }
    }
}