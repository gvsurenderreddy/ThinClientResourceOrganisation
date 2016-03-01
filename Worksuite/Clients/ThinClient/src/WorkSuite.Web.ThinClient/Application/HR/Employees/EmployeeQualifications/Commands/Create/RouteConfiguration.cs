using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Commands.Create
{
    public class RouteConfiguration
                        : ARouteConfiguration< CreateEmployeeQualificationController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee-qualification/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}