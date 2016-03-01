using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Presentation.List
{
    public class MetadataConfiguration
                        : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder< EmployeeQualificationDetails >
    {
        protected override void build_list_metadata( IDetailsListMetadataBuilder< EmployeeQualificationDetails > builder )
        {
            builder
                .id( Resources.list_id )
                .title( Resources.list_title )
                .presenter_id( Resources.route_name )
                ;
        }

        protected override void build_list_actions_metadata( IDetailsListActionsMetadataBuilder< EmployeeQualificationDetails > builder )
        {
            builder
                .add_action< global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.New >()
                .id( New.Resources.id )
                ;
        }
    }
}