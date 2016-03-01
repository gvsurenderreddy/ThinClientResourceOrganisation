using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Presentation.List
{
    public class MetadataConfiguration : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<EmployeeDocumentDetails>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<EmployeeDocumentDetails> builder)
        {
            builder
               .id(Resources.list_id)
               .title(Resources.list_title)
               .presenter_id(Resources.route_name)
                .is_sortable()
               ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<EmployeeDocumentDetails> builder)
        {
            builder
                .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.New>()
                .id(New.Resources.id)
                ;
        }
    }
}