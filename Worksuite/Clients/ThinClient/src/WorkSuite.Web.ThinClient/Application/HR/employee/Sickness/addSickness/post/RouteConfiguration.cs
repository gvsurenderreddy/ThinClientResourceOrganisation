using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.addSickness.post
{
    public class RouteConfiguration : ARouteConfiguration<AddSicknessPostController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/sickness/new/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}