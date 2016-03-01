using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetById;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.ViewSelf
{
    public class BreakTemplateViewModelBuilder
    {
        public AViewModelBuilder For(BreakTemplateIdentity the_break_template)
        {
            var response = _get_break_template_details_by_id
                                .execute(the_break_template)
                                ;

            return _view_model_builder
                        .add_content_header(response.result)
                        .add_details_list(response.result.all_breaks, () => new { the_break_template.template_id })
                        ;
        }

        public BreakTemplateViewModelBuilder(AViewModelBuilder the_view_model_builder,
                                                    IGetBreakTemplateDetailsById the_get_break_template_details_by_id
                                                 )
        {
            _view_model_builder = Guard.IsNotNull(the_view_model_builder,
                                                  "the_view_model_builder"
                                                 );
            _get_break_template_details_by_id = Guard.IsNotNull(the_get_break_template_details_by_id,
                                                                       "the_get_break_template_details_by_id"
                                                                      );
        }

        private readonly AViewModelBuilder _view_model_builder;
        private readonly IGetBreakTemplateDetailsById _get_break_template_details_by_id;
    }
}