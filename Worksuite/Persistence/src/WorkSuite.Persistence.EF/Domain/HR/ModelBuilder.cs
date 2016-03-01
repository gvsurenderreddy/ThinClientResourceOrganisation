using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR
{
    public class ModelBuilder : ModelConfigurationRegister
    {
        public ModelBuilder(string schema)
        {
            register(new Employees.ModelBuilder(schema));
            register(new Addresses.ModelBuilder(schema));
            register(new Notes.ModelBuilder(schema));
            register(new EmergencyContacts.ModelBuilder(schema));
            register(new EmployeeDocuments.ModelBuilder(schema));
            register(new EmployeeSkills.ModelBuilder(schema));
            register(new EmployeeQualifications.ModelBuilder(schema));

            register(new ReferenceData.Title.ModelBuilder(schema));
            register(new ReferenceData.Gender.ModelBuilder(schema));
            register(new ReferenceData.Relationship.ModelBuilder(schema));
            register(new ReferenceData.Skill.ModelBuilder(schema));
            register(new ReferenceData.Qualification.ModelBuilder(schema));
            register(new ReferenceData.Nationality.ModelBuilder(schema));
            register(new ReferenceData.MaritalStatus.ModelBuilder(schema));
            register(new ReferenceData.EthnicOrigin.ModelBuilder(schema));
            register(new ReferenceData.JobTitle.ModelBuilder(schema));
            register(new ReferenceData.Location.ModelBuilder(schema));
        }
    }
}