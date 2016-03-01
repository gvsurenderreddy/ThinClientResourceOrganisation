using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.PersonalDetails.Commands.Update
{

    public class RouteConfiguration : ARouteConfiguration<UpdatePersonalDetailsController> {
        public override string id {
            get { return Resources.id ; }
        }

        public override string url {
            get { return "employee/{employee_id}/update-personal-details"; }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }

    }

}