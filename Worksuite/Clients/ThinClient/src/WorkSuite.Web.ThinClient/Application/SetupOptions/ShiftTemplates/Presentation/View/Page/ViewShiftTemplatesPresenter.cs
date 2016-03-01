using System.Globalization;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.GetAll;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.View.Page
{
    public class ViewShiftTemplatesPresenter
                       : Presenter
    {
        public ActionResult Page()
        {
            response = query.execute();
            model_metadata_builder
                .id(Resources.page_id)
                .field_id_extension(x => x.shift_template_id.ToString(CultureInfo.InvariantCulture))
                .row_details_route_id(EditOrRemove.Page.Resources.page_id)
                .row_details_route_pramameter_factory(x => new {x.shift_template_id});

            displayTableView();
            var view_model = table_builder.build(response.result);

            return View(@"~\Views\SetupOptions\ShiftTemplates\View\Page.cshtml", view_model);
        }

        private void displayTableView()
        {
            field_metadata_builder
                .for_field(x => x.shift_title)
                .id("shift_title")
                .lable("Name");

            field_metadata_builder
                .for_field(x => x.colour)
                .id("colour")
                .lable("Colour");

            field_metadata_builder
                .for_field(x => x.start_time)
                .id("start_time")
                .lable("Start time");

            field_metadata_builder
                .for_field(x => x.end_time)
                .id("end_time")
                .lable("End time");

            field_metadata_builder
                .for_field(x => x.duration)
                .id("duration")
                .lable("Duration");

            field_metadata_builder
                .for_field(x => x.break_template_name)
                .id("break_template_name")
                .lable("Break template");

        }

        public ViewShiftTemplatesPresenter
                        ( IGetAllShiftTemplates the_query
                        , ITableModelMetadataBuilder<ShiftTemplateDetails> the_model_metadata_builder
                        , ITableFieldsMetadataBuilder<ShiftTemplateDetails> the_field_metadata_builder
                        , TableBuilder<ShiftTemplateDetails> the_table_builder)
        {
            query = Guard.IsNotNull(the_query, "the_query");
            model_metadata_builder = Guard.IsNotNull(the_model_metadata_builder, "the_model_metadata_builder");
            field_metadata_builder = Guard.IsNotNull(the_field_metadata_builder, "the_field_metadata_builder");
            table_builder = Guard.IsNotNull(the_table_builder, "the_table_builder");
        }

        private GetAllShiftTemplateResponse response;
        private readonly IGetAllShiftTemplates query;
        private readonly ITableModelMetadataBuilder<ShiftTemplateDetails> model_metadata_builder;
        private readonly ITableFieldsMetadataBuilder<ShiftTemplateDetails> field_metadata_builder;
        private readonly TableBuilder<ShiftTemplateDetails> table_builder;
    }
}