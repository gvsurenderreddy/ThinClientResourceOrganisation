using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit
{
    public class ModelBuilder : ModelConfigurationRegister
    {
        public ModelBuilder(string schema)
        {
            register(new Employees.ModelBuilder(schema));
            register(new Employees.AuditRecords.ModelBuilder(schema));
            register(new Employees.EmploymentDetails.ModelBuilder(schema));
            register(new Employees.PersonalDetails.ModelBuilder(schema));
            register(new Employees.ContactDetails.ModelBuilder(schema));
            register(new Employees.AddressDetails.ModelBuilder(schema));
            register(new Employees.ImageDetails.ModelBuilder(schema));
            register(new Employees.EmergencyContactDetails.ModelBuilder(schema));
            register(new Employees.NoteDetails.ModelBuilder(schema));
            register(new Employees.DocumentDetails.ModelBuilder(schema));
            register(new Employees.SkillDetails.ModelBuilder(schema));
            register(new Employees.QualificationDetails.ModelBuilder(schema));
        }
    }
}