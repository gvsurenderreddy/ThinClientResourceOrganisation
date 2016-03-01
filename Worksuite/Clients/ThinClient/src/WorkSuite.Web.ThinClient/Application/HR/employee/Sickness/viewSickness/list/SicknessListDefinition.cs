using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listItems;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.viewSickness.list
{
    public class SicknessListDefinition : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<SicknessListItem>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<SicknessListItem> builder)
        {
            builder
              .id(Resources.id)
              .title(content_repository.get_resource_value("view_sickness_list_resource_title"))
              ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<SicknessListItem> builder)
        {
            builder
                  .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.New>()
                  .id(addSickness.editor.Resources.id)
                  ;
        }
    }
}