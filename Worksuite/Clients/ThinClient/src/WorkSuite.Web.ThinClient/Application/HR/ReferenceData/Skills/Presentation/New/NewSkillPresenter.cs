using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.GetCreateRequest;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Presentation.New
{
    public class NewSkillPresenter
                        :   Presenter
    {
        public NewSkillPresenter(   IGetCreateSkillRequest getNewSkillRequest,
                                    EditorBuilder< CreateSkillRequest > theNewSkillEditorBuilder
                                )
        {
            _newSkillRequest = Guard.IsNotNull( getNewSkillRequest, "getNewSkillRequest" );
            _newSkillEditorBuilder = Guard.IsNotNull( theNewSkillEditorBuilder, "theNewSkillEditorBuilder" );
        }

        public ActionResult Editor()
        {
            var response = _newSkillRequest.create();
            var viewModel = _newSkillEditorBuilder.build( response.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", viewModel );
        }

        public readonly IGetCreateSkillRequest _newSkillRequest;
        public readonly EditorBuilder< CreateSkillRequest > _newSkillEditorBuilder;
    }
}