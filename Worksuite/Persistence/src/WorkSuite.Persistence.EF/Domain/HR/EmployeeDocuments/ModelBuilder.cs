using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.EmployeeDocuments
{
    public class ModelBuilder : ModelConfiguration<EmployeeDocument>
    {
        public ModelBuilder(string schema)
        {

            Map(m => m.ToTable("EmployeeDocument", schema));
        }
    }
}