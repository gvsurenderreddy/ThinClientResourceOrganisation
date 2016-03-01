using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.listItems;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.listReport
{
    public class GetHolidayListItems : IGetHolidayListItems
    {
        public GetHolidayListItemsResponse execute( EmployeeIdentity request )
        {

            var result = holiday_list_report_repository
                    .Entities
                    .Where(e => e.employee_id == request.employee_id)
                    .OrderBy(d => d.holiday_date)
                    .ToList()
                    .Select(item => new HolidayListItem
                    {
                        employee_id = item.employee_id,
                        holiday_date_display = item.holiday_date.FormatForReport(),
                        holiday_date = item.holiday_date
                    })
                    ;

            var response = new GetHolidayListItemsResponse
            {
                has_errors = false,
                messages = null,
                result = result
            };

            return response;

        }

        public GetHolidayListItems( IQueryRepository<HolidayListView> holiday_list_report_repository )
        {
            this.holiday_list_report_repository = Guard.IsNotNull(holiday_list_report_repository, "holiday_list_report_repository");
        }

        private readonly IQueryRepository<HolidayListView> holiday_list_report_repository;

    }
}
