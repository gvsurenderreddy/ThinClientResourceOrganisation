using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Commands.Create
{
    public class RouteConfiguration
                        :   ARouteConfiguration<CreateSkillController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "skills/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}