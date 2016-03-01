using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.EmployeeSkills
{
    public class ModelBuilder : ModelConfiguration<EmployeeSkill>
    {
        public ModelBuilder(string schema)
        {

            Map(m => m.ToTable("EmployeeSkill", schema));
        }
    }
}