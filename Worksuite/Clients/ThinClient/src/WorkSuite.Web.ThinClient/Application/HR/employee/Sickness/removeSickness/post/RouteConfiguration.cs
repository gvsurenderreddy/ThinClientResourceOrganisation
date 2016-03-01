using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.removeSickness.post
{
    public class RouteConfiguration : ARouteConfiguration<RemoveSicknessController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/sickness/remove-sickness"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}