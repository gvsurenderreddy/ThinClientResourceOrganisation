using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Presentation.List
{
    public class SkillListPresenter
                        :   Presenter
    {
        public SkillListPresenter(  IGetDetailsOfAllSkills getAllSkillsQuery,
                                    DetailsListBuilder< SkillDetails > theSkillDetailsListBuilder
                                 )
        {
            _getAllSkills = Guard.IsNotNull( getAllSkillsQuery, "getAllSkillsQuery" );
            _skillDetailsListBuilder = Guard.IsNotNull( theSkillDetailsListBuilder, "theSkillDetailsListBuilder" );
        }

        public ActionResult List()
        {
            var response = _getAllSkills.execute();
            var viewModel = _skillDetailsListBuilder.build( response.result );

            return View( @"~\Views\Shared\Views\DetailsList.cshtml", viewModel );
        }

        private readonly IGetDetailsOfAllSkills _getAllSkills;
        private readonly DetailsListBuilder< SkillDetails > _skillDetailsListBuilder;
    }
}