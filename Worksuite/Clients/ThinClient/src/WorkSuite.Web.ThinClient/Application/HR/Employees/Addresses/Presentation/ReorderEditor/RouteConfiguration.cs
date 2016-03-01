using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.ReorderEditor
{
    public class RouteConfiguration : ARouteConfiguration<ReorderAddressEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/address/{address_id}/address-reorder-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}