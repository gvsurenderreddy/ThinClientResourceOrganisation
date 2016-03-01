using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Commands.Update
{
    public class RouteConfiguration
                    : ARouteConfiguration<UpdateJobTitleController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "job-titles/{id}/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}