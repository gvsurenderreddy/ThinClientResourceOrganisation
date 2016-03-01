using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.ThinClient.Query.HR.employee.ViewSchedules;

namespace WTS.WorkSuite.Persistence.EF.Domain.ThinClient.Query.EmployeeViewScheduleTableViews
{
    public class ModelBuilder : ModelConfiguration<EmployeeViewScheduleTableView>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeeViewScheduleTableView", schema));
        }
    }
}
