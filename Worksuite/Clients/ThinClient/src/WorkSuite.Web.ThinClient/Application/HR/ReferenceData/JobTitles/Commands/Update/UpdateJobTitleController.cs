using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Commands.Update
{
    public class UpdateJobTitleController
                        : Controller
    {
        public ActionResult SubmitRequest(UpdateJobTitleRequest the_update_job_title_request)
        {
            var response = _update_job_title
                                .execute(the_update_job_title_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public UpdateJobTitleController(IUpdateJobTitle the_update_job_title)
        {
            _update_job_title = Guard.IsNotNull(the_update_job_title, "the_update_job_title");
        }

        private readonly IUpdateJobTitle _update_job_title;
    }
}