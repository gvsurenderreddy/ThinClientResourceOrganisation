using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Commands.Create
{
    public class RouteConfiguration : ARouteConfiguration<CreateEmployeeDocumentController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee-document/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}