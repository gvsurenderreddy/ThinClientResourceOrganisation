using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Commands.Update
{
    public class RouteConfiguration
                        : ARouteConfiguration< UpdateNationalityController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "nationalities/{id}/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}