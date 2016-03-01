using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Queries.GetAll;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.List
{
    public class BreakListPresenter
                    : Presenter
    {
        public ActionResult List(BreakTemplateIdentity the_break_template_identity)
        {
            var all_breaks = _get_details_of_all_breaks
                                        .execute(new BreakTemplateIdentity { template_id = the_break_template_identity.template_id })
                                        ;

            var view_model = _break_details_list_builder
                                    .build(all_breaks.result)
                                    ;

            return View(@"~\Views\Shared\Views\DetailsList.cshtml", view_model);
        }

        public BreakListPresenter(IGetDetailsOfAllBreaks the_get_details_of_all_breaks,
                                        DetailsListBuilder<BreakDetails> the_break_details_list_builder
                                      )
        {
            _get_details_of_all_breaks = Guard.IsNotNull(the_get_details_of_all_breaks,
                                                               "the_get_details_of_all_breaks"
                                                              );
            _break_details_list_builder = Guard.IsNotNull(the_break_details_list_builder,
                                                                "the_break_details_list_builder"
                                                               );
        }

        private readonly IGetDetailsOfAllBreaks _get_details_of_all_breaks;
        private readonly DetailsListBuilder<BreakDetails> _break_details_list_builder;
    }
}