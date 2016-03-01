using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.addHoliday.editor
{
    public class RouteConfiguration : ARouteConfiguration<AddHolidayEditorPresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/holidays/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}