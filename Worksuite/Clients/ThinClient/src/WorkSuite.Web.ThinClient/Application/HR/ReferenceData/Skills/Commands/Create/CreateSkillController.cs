using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.Create;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Commands.Create
{
    public class CreateSkillController
                            :   Controller
    {
        public CreateSkillController( ICreateSkill createSkillCommand )
        {
            _createSkill = Guard.IsNotNull( createSkillCommand, "createSkillCommand" );
        }

        public ActionResult SubmitRequest( CreateSkillRequest createSkillRequest )
        {
            var response = _createSkill.execute( createSkillRequest );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly ICreateSkill _createSkill;
    }
}