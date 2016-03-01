using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Help.Command.Update
{
    public class RouteConfiguration
                 :ARouteConfiguration<UpdateHelpController>
    {
        public override string id
        {
            get { return Resources.editor_id; }
        }

        public override string url
        {
            get { return "help/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}