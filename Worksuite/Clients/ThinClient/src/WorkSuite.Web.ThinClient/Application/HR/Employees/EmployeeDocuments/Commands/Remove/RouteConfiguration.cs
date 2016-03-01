using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Commands.Remove
{
    public class RouteConfiguration : ARouteConfiguration<RemoveEmployeeDocumentController>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/document/{employee_document_id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}