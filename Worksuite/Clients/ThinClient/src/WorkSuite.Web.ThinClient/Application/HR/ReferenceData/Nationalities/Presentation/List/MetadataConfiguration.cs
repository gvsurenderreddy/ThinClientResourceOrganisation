using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Presentation.List
{
    public class MetadataConfiguration
                        : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder< NationalityDetails >
    {
        protected override void build_list_metadata( IDetailsListMetadataBuilder< NationalityDetails > builder )
        {
            builder
                .id( Resources.list_id )
                .title( Resources.list_title )
                .presenter_id( Resources.route_name )
                ;
        }

        protected override void build_list_actions_metadata( IDetailsListActionsMetadataBuilder< NationalityDetails > builder )
        {
            builder
                .add_action< DetailsList.New >()
                .id( Nationalities.Presentation.New.Resources.id )
                ;
        }
    }
}