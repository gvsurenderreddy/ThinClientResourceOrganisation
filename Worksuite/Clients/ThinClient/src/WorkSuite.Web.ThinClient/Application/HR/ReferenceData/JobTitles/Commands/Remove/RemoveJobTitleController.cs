using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Commands.Remove
{
    public class RemoveJobTitleController
                    : Controller
    {
        public ActionResult SubmitRequest(RemoveJobTitleRequest the_remove_job_title_request)
        {
            var response = _remove_job_title
                                .execute(the_remove_job_title_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemoveJobTitleController(IRemoveJobTitle the_remove_job_title)
        {
            _remove_job_title = Guard.IsNotNull(the_remove_job_title, "the_remove_job_title");
        }

        private readonly IRemoveJobTitle _remove_job_title;
    }
}