using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.ThinClient.Query
{
    public class ModelBuilder
                        : ModelConfigurationRegister
    {
        public ModelBuilder(string schema)
        {
            register(new HolidayListViews.ModelBuilder(schema));
            register(new SicknessListViews.ModelBuilder(schema));
            register(new EmployeeViewScheduleTableViews.ModelBuilder(schema));
            register(new AllocatableResourcesTableViews.ModelBuilder(schema));
            register(new ConfirmResourceAllocationEditorViews.ModelBuilder(schema));
            register(new AllocatedResourcesListViews.ModelBuilder(schema));
        }
    }
}
