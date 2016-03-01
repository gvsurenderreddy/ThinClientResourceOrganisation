using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.listItems;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.viewHolidays.list
{
    public class HolidayListDefinition : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<HolidayListItem>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<HolidayListItem> builder)
        {
            builder
                .id(Resources.id)
                .title(content_repository.get_resource_value("view_holidays_list_resource_title"))
                ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<HolidayListItem> builder)
        {
            builder
                .add_action<DetailsList.New>()
                .id(addHoliday.editor.Resources.page_id)
                ;
        }
    }
}