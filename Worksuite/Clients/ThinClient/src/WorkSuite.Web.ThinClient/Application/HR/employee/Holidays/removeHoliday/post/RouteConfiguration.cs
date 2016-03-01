using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.removeHoliday.post
{
    public class RouteConfiguration : ARouteConfiguration<RemoveHolidayController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/holiday/remove-holiday"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}