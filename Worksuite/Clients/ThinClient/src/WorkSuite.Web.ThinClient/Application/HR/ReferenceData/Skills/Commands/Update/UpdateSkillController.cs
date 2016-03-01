using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Commands.Update
{
    public class UpdateSkillController
                        :   Controller
    {
        public UpdateSkillController( IUpdateSkill updateSkillCommand )
        {
            _updateSkill = Guard.IsNotNull( updateSkillCommand, "updateSkillCommand" );
        }

        public ActionResult SubmitRequest( UpdateSkillRequest updateSkillRequest )
        {
            var response = _updateSkill.execute( updateSkillRequest );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly IUpdateSkill _updateSkill;
    }
}