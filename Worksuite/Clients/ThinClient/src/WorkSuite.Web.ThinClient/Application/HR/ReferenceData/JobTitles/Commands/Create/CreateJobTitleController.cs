using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Commands.Create
{
    public class CreateJobTitleController
                        : Controller
    {
        public ActionResult SubmitRequest(CreateJobTitleRequest the_create_job_title_request)
        {
            var response = _create_job_title_command
                                .execute(the_create_job_title_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public CreateJobTitleController(ICreateJobTitle the_create_job_title_command)
        {
            _create_job_title_command = Guard.IsNotNull(the_create_job_title_command, "the_create_job_title_command");
        }

        private readonly ICreateJobTitle _create_job_title_command;
    }
}