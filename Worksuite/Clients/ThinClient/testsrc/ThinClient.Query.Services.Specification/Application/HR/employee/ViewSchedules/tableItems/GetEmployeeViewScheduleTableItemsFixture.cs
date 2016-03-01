using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.ViewSchedules.tableItems;
using WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules.tableItems.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules.tableItems
{
    public class GetEmployeeViewScheduleTableItemsFixture
    {

        public void execute_query()
        {
            Guard.IsNotNull(request, "request");

            response = query.execute(request);
        }

        public void set_request(EmployeeIdentity request)
        {
            this.request = request;
        }

        public EmployeeViewScheduleTableViewBuilder add()
        {
            return employee_view_schedule_table_view_helper.add();
        }

        public GetEmployeeViewScheduleTableItemsFixture( EmployeeViewScheduleTableViewHelper the_employee_view_schedule_table_view_helper
                                                       , IGetEmployeeViewScheduleTableItems the_query)
        {
            employee_view_schedule_table_view_helper = Guard.IsNotNull(the_employee_view_schedule_table_view_helper, "the_employee_view_schedule_table_view_helper");
            query = Guard.IsNotNull(the_query, "the_query");
        }

        private readonly EmployeeViewScheduleTableViewHelper employee_view_schedule_table_view_helper;
        private readonly IGetEmployeeViewScheduleTableItems query;
        private EmployeeIdentity request;
        public GetEmployeeViewScheduleTableItemsResponse response { private set; get; }
    }
}
