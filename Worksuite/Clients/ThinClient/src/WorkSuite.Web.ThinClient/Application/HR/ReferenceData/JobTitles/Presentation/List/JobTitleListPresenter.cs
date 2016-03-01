using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Presentation.List
{
    public class JobTitleListPresenter
                    : Presenter
    {
        public ActionResult List()
        {
            var all_job_titles = _get_all_job_titles
                                    .execute()
                                    ;

            var view_model = _job_titles_list_builder
                                    .build(all_job_titles.result)
                                    ;

            return View(@"~\Views\Shared\Views\DetailsList.cshtml", view_model);
        }

        public JobTitleListPresenter(IGetDetailsOfAllJobTitles the_get_all_job_titles,
                                     DetailsListBuilder<JobTitleDetails> the_job_titles_list_builder
                                    )
        {
            _get_all_job_titles = Guard.IsNotNull(the_get_all_job_titles, "the_get_all_job_titles");
            _job_titles_list_builder = Guard.IsNotNull(the_job_titles_list_builder, "the_job_titles_list_builder");
        }

        private readonly IGetDetailsOfAllJobTitles _get_all_job_titles;
        private readonly DetailsListBuilder<JobTitleDetails> _job_titles_list_builder;
    }
}