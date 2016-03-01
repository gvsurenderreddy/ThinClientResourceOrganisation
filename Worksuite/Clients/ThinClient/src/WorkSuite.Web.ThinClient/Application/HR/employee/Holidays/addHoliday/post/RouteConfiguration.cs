using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.addHoliday.post
{
    public class RouteConfiguration : ARouteConfiguration<NewHolidayPostController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/holidays/new/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }

    }
}