using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.EmployeeQualifications
{
    public class ModelBuilder
                    : ModelConfiguration< EmployeeQualification >
    {
        public ModelBuilder(string schema)
        {
            Map( m => m.ToTable( "EmployeeQualification", schema ) );
        }
    }
}