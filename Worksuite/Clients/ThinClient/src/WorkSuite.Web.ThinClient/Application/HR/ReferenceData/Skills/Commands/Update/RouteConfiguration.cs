using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Commands.Update
{
    public class RouteConfiguration
                        :   ARouteConfiguration< UpdateSkillController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "skills/{id}/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}