using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.viewSickness.get
{
    public class RouteConfiguration : APageRouteConfiguration<ViewSicknessPagePresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/sickness"; }
        }
    }
}