using System.Collections.Generic;
using System.Globalization;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.ViewSchedules.tableItems;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.ViewSchedules.viewSchedules.Presentation.Page
{
    public class ViewScheduleTableViewModelBuilder
    {
        public IsAViewElement build
            (IEnumerable<EmployeeViewScheduleTableItem> employees_view_schedule_table_items)
        {
            return this
                .set_schedules_view(employees_view_schedule_table_items)
                .define_table_model()
                .define_table_rows()
                .build_view_model()
                ;
        }


        private ViewScheduleTableViewModelBuilder set_schedules_view
            (IEnumerable<EmployeeViewScheduleTableItem> employees_view_schedule_table_items)
        {

            schedule_table_items = Guard.IsNotNull(employees_view_schedule_table_items, "employees_view_schedule_table_items");
            return this;
        }

        private ViewScheduleTableViewModelBuilder define_table_model()
        {
            model_metadata_builder
                .id(Resources.page_id)
                .field_id_extension(x => x.employee_id.ToString(CultureInfo.InvariantCulture))
                .row_details_route_pramameter_factory(x => new { x.employee_id }); ;

            return this;
        }

        private ViewScheduleTableViewModelBuilder define_table_rows()
        {

            field_metadata_builder
                .for_field(x => x.display_date)
                .id("display_date")
                .lable("Date");

            return this;
        }

        private IsAViewElement build_view_model()
        {

            Guard.IsNotNull(schedule_table_items, "schedule_table_items");

            return table_builder.build(schedule_table_items);
        }

        public ViewScheduleTableViewModelBuilder
            (ITableModelMetadataBuilder<EmployeeViewScheduleTableItem> the_model_metadata_builder,
                ITableFieldsMetadataBuilder<EmployeeViewScheduleTableItem> the_field_metadata_builder,
                TableBuilder<EmployeeViewScheduleTableItem> the_table_builder)
        {


            model_metadata_builder = Guard.IsNotNull(the_model_metadata_builder, "the_model_metadata_builder");
            field_metadata_builder = Guard.IsNotNull(the_field_metadata_builder, "the_field_metadata_builder");
            table_builder = Guard.IsNotNull(the_table_builder, "the_table_builder");
        }


        private IEnumerable<EmployeeViewScheduleTableItem> schedule_table_items;

        private readonly ITableModelMetadataBuilder<EmployeeViewScheduleTableItem> model_metadata_builder;
        private readonly ITableFieldsMetadataBuilder<EmployeeViewScheduleTableItem> field_metadata_builder;
        private readonly TableBuilder<EmployeeViewScheduleTableItem> table_builder;
    }
}