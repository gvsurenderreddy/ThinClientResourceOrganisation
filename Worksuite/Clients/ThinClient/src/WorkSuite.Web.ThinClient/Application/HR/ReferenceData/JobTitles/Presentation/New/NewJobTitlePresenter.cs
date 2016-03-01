using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.GetCreateRequest;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Presentation.New
{
    public class NewJobTitlePresenter
                    : Presenter
    {
        public ActionResult Editor()
        {
            var request = _new_job_title_request
                                .create()
                                ;

            var view_model = _job_title_editor_builder
                                .build(request.result)
                                ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewJobTitlePresenter(IGetCreateJobTitleRequest the_new_job_title_request,
                                    EditorBuilder<CreateJobTitleRequest> the_job_title_editor_builder
                                   )
        {
            _new_job_title_request = Guard.IsNotNull(the_new_job_title_request, "the_new_job_title_request");
            _job_title_editor_builder = Guard.IsNotNull(the_job_title_editor_builder, "the_job_title_editor_builder");
        }

        private readonly IGetCreateJobTitleRequest _new_job_title_request;
        private readonly EditorBuilder<CreateJobTitleRequest> _job_title_editor_builder;
    }
}