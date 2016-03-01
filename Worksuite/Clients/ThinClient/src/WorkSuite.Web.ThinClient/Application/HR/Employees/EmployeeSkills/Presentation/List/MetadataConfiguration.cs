using Content.Services.HR.Messages;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.List
{
    public class MetadataConfiguration : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<EmployeeSkillDetails>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<EmployeeSkillDetails> builder)
        {
            builder
               .id(Resources.list_id)
               .title(Resources.list_title)
               .description(ValidationMessages.help_05_0003)
               .presenter_id(Resources.route_name)
               .is_sortable()
               ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<EmployeeSkillDetails> builder)
        {
            builder
                .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.New>()
                .id(New.Resources.id)
                ;
        }
    }
}