using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Presentation.List
{
    public class MetadataConfiguration
                        : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder< QualificationDetails >
    {
        protected override void build_list_metadata( IDetailsListMetadataBuilder< QualificationDetails > builder )
        {
            builder
                .id( Resources.list_id )
                .title( Resources.list_title )
                .presenter_id( Resources.route_name )
                ;
        }

        protected override void build_list_actions_metadata( IDetailsListActionsMetadataBuilder< QualificationDetails > builder )
        {
            builder
                .add_action< DetailsList.New >()
                .id( Qualifications.Presentation.New.Resources.id )
                ;
        }
    }
}