using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.ViewSchedules.viewSchedules.Presentation.Page
{
    public class RouteConfiguration : APageRouteConfiguration<ViewEmployeeSchedulePresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/employee-schedule"; }
        }
    }
}