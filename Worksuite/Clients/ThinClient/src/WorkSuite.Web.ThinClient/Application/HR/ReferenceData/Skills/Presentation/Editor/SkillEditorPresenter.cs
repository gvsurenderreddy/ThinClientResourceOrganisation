using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.GetUpdateRequest;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Presentation.Editor
{
    public class SkillEditorPresenter
                        :   Presenter
    {
        public SkillEditorPresenter(    IGetUpdateSkillRequest updateSkillRequest,
                                        EditorBuilder< UpdateSkillRequest > theUpdateSkillEditorBuilder
                                   )
        {
            _getUpdateSkillRequest = Guard.IsNotNull( updateSkillRequest, "updateSkillRequest" );
            _updateSkillEditorBuilder = Guard.IsNotNull( theUpdateSkillEditorBuilder, "theUpdateSkillEditorBuilder" );
        }

        public ActionResult Editor( ReferenceDataIdentity skill )
        {
            var request = _getUpdateSkillRequest.create( skill );
            var viewModel = _updateSkillEditorBuilder.build(request.result);

            return View(@"~\Views\Shared\Views\Editor.cshtml", viewModel);
        }

        private readonly IGetUpdateSkillRequest _getUpdateSkillRequest;
        private readonly EditorBuilder< UpdateSkillRequest > _updateSkillEditorBuilder;
    }
}