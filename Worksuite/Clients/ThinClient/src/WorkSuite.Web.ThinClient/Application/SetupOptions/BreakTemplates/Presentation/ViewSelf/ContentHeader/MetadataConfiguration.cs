using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetById;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.ViewSelf.ContentHeader
{
    public class MetadataConfiguration
                        : ContentHeaderDefinitionsBuilder<GetBreakTemplateByIdResponse>
    {
        protected override void build_model_definitions(DynamicContentHeaderStaticDefinitionBuilder<GetBreakTemplateByIdResponse> model_definitions_builder)
        {
            model_definitions_builder
                .title(sbt => sbt.is_hidden ? (sbt.template_name + " (Hidden)") : (sbt.template_name))
                ;
        }

        protected override void build_action_definitions(DynamicContentHeaderActionsStaticDefintionBuilder<GetBreakTemplateByIdResponse> actions_definitions_builder)
        {
            actions_definitions_builder
                .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Edit>()
                .url_from_route(sbt => Presentation.EditEditor.Resources.id, sbt => new { sbt.template_id })
                .add()
                ;

            actions_definitions_builder
                .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Remove>()
                .url_from_route(sbt => Presentation.RemoveEditor.Resources.id, sbt => new { sbt.template_id })
                .add()
                ;
        }
    }
}