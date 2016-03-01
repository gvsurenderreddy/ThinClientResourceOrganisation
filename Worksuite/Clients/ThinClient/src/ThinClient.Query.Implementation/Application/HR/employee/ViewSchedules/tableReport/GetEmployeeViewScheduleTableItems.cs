using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.ViewSchedules.tableItems;
using WTS.WorkSuite.ThinClient.Query.HR.employee.ViewSchedules;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.ViewSchedules.tableReport
{
    public class GetEmployeeViewScheduleTableItems : IGetEmployeeViewScheduleTableItems
    {
        public GetEmployeeViewScheduleTableItemsResponse execute(EmployeeIdentity request)
        {
            Guard.IsNotNull(request, "request");

            var result = employee_view_schedule_repository
                    .Entities
                    .Where(e => e.employee_id == request.employee_id)
                    .OrderBy(d => d.display_date)
                    .ToList()
                    .Select(item => new EmployeeViewScheduleTableItem()
                    {
                        employee_id = item.employee_id,
                        display_date = item.display_date.FormatForReport(),
                    }).ToList();


                var response = new GetEmployeeViewScheduleTableItemsResponse
                {
                    has_errors = false,
                    messages = null,
                    result = result
                };

                return response;
        }

        public GetEmployeeViewScheduleTableItems(IQueryRepository<EmployeeViewScheduleTableView> the_employee_view_schedule_repository)
        {
            employee_view_schedule_repository = Guard.IsNotNull(the_employee_view_schedule_repository, "the_employee_view_schedule_repository");

        }

        private readonly IQueryRepository<EmployeeViewScheduleTableView> employee_view_schedule_repository;
    }
}
