using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Relationships.Commands.Create
{
    public class RouteConfiguration
                    : ARouteConfiguration<CreateRelationshipController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "relationships/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }

    }
}