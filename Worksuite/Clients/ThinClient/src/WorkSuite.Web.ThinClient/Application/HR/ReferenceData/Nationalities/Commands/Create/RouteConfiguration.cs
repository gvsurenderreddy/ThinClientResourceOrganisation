using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Commands.Create
{
    public class RouteConfiguration
                        : ARouteConfiguration< CreateNationalityController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "nationalities/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}