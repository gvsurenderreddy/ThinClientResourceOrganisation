using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Commands.Remove
{
    public class RemoveSkillController
                    :   Controller
    {
        public RemoveSkillController( IRemoveSkill removeSkillCommand )
        {
            _removeSkill = Guard.IsNotNull( removeSkillCommand, "removeSkillCommand" );
        }

        public ActionResult SubmitRequest( RemoveSkillRequest removeSkillRequest )
        {
            var response = _removeSkill.execute( removeSkillRequest );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly IRemoveSkill _removeSkill;
    }
}