using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees
{
    public class ModelBuilder
                    : ModelConfiguration<EmployeeAuditTrail>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeeAuditTrail", schema));

            // configure cascading deletes
            HasMany(m => m.employee_audit)
                .WithRequired();

            HasMany(m => m.employment_details_audit)
                .WithRequired();

            HasMany(m => m.personal_details_audit)
                .WithRequired();

            HasMany(m => m.contact_details_audit)
                .WithRequired();

            HasMany(m => m.address_details_audit)
                .WithRequired();

            HasMany(m => m.image_details_audit)
                .WithRequired();

            HasMany(m => m.emergency_contact_details_audit)
                .WithRequired();

            HasMany(m => m.note_details_audit)
                .WithRequired();

            HasMany(m => m.document_details_audit)
                .WithRequired();

            HasMany(m => m.skill_details_audit)
                .WithRequired();

            HasMany(m => m.qualification_details_audit)
                .WithRequired();
        }
    }
}