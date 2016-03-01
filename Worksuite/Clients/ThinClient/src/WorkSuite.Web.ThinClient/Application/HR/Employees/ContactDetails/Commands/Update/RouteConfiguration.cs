using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.ContactDetails.Commands.Update 
{

    public class RouteConfiguration : ARouteConfiguration<UpdateContactDetailsController> 
    {
        public override string id {
            get { return Resources.id ; }
        }

        public override string url {
            get { return "employee/{employee_id}/update-contact-details"; }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }

    }

}