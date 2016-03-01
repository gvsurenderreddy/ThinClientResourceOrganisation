using WTS.WorkSuite.HR.HR.Employees.Addresses.Details;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.List
{
    //This class will be used once we have all our Address in place.

    public class MetadataConfiguration : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<AddressDetails>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<AddressDetails> builder)
        {
            builder
               .id(Resources.list_id)
               .title(Resources.list_title)
               .presenter_id(Resources.route_name)
               .is_sortable()
               ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<AddressDetails> builder)
        {
            builder
                .add_action<DetailsList.New>()
                .id(New.Resources.id)
                ;
        }
    }
}