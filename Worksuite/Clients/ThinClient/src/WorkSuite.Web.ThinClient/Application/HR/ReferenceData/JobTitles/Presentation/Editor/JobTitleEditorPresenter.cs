using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.GetUpdateRequest;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Presentation.Editor
{
    public class JobTitleEditorPresenter
                        : Presenter
    {
        public ActionResult Editor(ReferenceDataIdentity the_job_title)
        {
            var request = _get_update_job_title_request
                                .create(the_job_title)
                                ;

            var view_model = _update_job_title_editor_builder
                                .build(request.result)
                                ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public JobTitleEditorPresenter(IGetUpdateJobTitleRequest the_get_update_job_title_request,
                                       EditorBuilder<UpdateJobTitleRequest> the_update_job_title_editor_builder
                                      )
        {
            _get_update_job_title_request = Guard.IsNotNull(the_get_update_job_title_request,
                                                            "the_get_update_job_title_request"
                                                           );
            _update_job_title_editor_builder = Guard.IsNotNull(the_update_job_title_editor_builder,
                                                               "the_update_job_title_editor_builder"
                                                              );
        }

        private readonly IGetUpdateJobTitleRequest _get_update_job_title_request;
        private readonly EditorBuilder<UpdateJobTitleRequest> _update_job_title_editor_builder;
    }
}