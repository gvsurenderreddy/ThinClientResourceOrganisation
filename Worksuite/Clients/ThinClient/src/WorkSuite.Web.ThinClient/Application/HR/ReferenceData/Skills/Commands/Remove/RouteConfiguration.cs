using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Commands.Remove
{
    public class RouteConfiguration
                        :   ARouteConfiguration< RemoveSkillController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "skills/{id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}