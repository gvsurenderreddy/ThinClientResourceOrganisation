using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Commands.Update
{
    public class RouteConfiguration : ARouteConfiguration<UpdateTitleController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "title/{id}/update-title-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}