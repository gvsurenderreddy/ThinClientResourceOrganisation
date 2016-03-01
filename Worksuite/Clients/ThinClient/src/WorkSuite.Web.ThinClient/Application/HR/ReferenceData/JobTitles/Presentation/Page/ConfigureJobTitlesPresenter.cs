using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Presentation.Page
{
    public class ConfigureJobTitlesPresenter
                        : Presenter
    {
        public ActionResult Page()
        {
            var all_job_titles = _get_all_job_titles_query
                                    .execute()
                                    ;

            var view_model = _job_tiltles_list_builder
                                    .build(all_job_titles.result)
                                    ;

            return View(@"~\Views\HR\ReferenceData\JobTitles\Page.cshtml", view_model);
        }

        public ConfigureJobTitlesPresenter(IGetDetailsOfAllJobTitles the_get_all_job_titles_query,
                                           DetailsListBuilder<JobTitleDetails> the_job_tiltles_list_builder
                                          )
        {
            _get_all_job_titles_query = Guard.IsNotNull(the_get_all_job_titles_query, "the_get_all_job_titles_query");
            _job_tiltles_list_builder = Guard.IsNotNull(the_job_tiltles_list_builder, "the_job_tiltles_list_builder");
        }

        private readonly IGetDetailsOfAllJobTitles _get_all_job_titles_query;
        private readonly DetailsListBuilder<JobTitleDetails> _job_tiltles_list_builder;
    }
}