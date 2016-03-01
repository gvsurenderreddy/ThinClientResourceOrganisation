using System.Globalization;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAll;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.ViewAll.Page
{
    public class BreakTemplatesViewAllPresenter
                    : Presenter
    {
        public ActionResult Page()
        {
            GetAllBreakTemplatesResponse response = _get_all_break_templates_details
                                                                .execute()
                                                                ;

            _break_template_details_model_metadata_builder
                .id(Resources.page_id)
                .field_id_extension(sbt => sbt.template_id.ToString(CultureInfo.InvariantCulture))
                .row_details_route_id(ViewSelf.Page.Resources.page_id)
                .row_details_route_pramameter_factory(sbt => new { sbt.template_id })
                ;

            displayTableView();

            var view_model = _break_template_details_table_builder
                                    .build(response.result)
                                    ;

            return View(@"~\Views\SetupOptions\BreakTemplates\ViewAll\Page.cshtml", view_model);
        }

        private void displayTableView()
        {
            _break_template_details_field_metadata_builder
                .for_field(sbt => sbt.template_name)
                .id(sbt => sbt.template_id + "template_name")
                .lable("Name")
                ;

            _break_template_details_field_metadata_builder
                .for_field(sbt => sbt.total_break_duration)
                .id(sbt => sbt.template_id + "total_break_duration")
                .lable("Total break duration")
                ;

            _break_template_details_field_metadata_builder
                .for_field(sbt => sbt.break_details)
                .id(sbt => sbt.template_id + "break_details")
                .lable("Break details")
                ;

            _break_template_details_field_metadata_builder
                .for_field(sbt => sbt.all_associated_shift_templates)
                .id(sbt => sbt.template_id + "all_associated_shift_templates")
                .lable("Associated shift templates")
                ;

            _break_template_details_field_metadata_builder
                .for_field(sbt => sbt.hidden_status)
                .id(sbt => sbt.template_id + "hidden_status")
                .lable("Status")
                ;
        }

        public BreakTemplatesViewAllPresenter(IGetAllBreakTemplatesDetails the_get_all_break_templates_details,
                                                TableBuilder<BreakTemplateDetails> the_break_template_details_table_builder,
                                                ITableModelMetadataBuilder<BreakTemplateDetails> the_break_template_details_model_metadata_builder,
                                                ITableFieldsMetadataBuilder<BreakTemplateDetails> the_break_template_details_field_metadata_builder
                                               )
        {
            _get_all_break_templates_details = Guard.IsNotNull(the_get_all_break_templates_details,
                                                                    "the_get_all_break_templates_details"
                                                                    );
            _break_template_details_table_builder = Guard.IsNotNull(the_break_template_details_table_builder,
                                                                         "the_break_template_details_table_builder"
                                                                         );
            _break_template_details_model_metadata_builder = Guard.IsNotNull(the_break_template_details_model_metadata_builder,
                                                                            "the_break_template_details_model_metadata_builder"
                                                                            );
            _break_template_details_field_metadata_builder = Guard.IsNotNull(the_break_template_details_field_metadata_builder,
                                                                                  "the_break_template_details_field_metadata_builder"
                                                                                  );
        }

        private readonly IGetAllBreakTemplatesDetails _get_all_break_templates_details;
        private readonly TableBuilder<BreakTemplateDetails> _break_template_details_table_builder;
        private readonly ITableModelMetadataBuilder<BreakTemplateDetails> _break_template_details_model_metadata_builder;

        private readonly ITableFieldsMetadataBuilder<BreakTemplateDetails>
            _break_template_details_field_metadata_builder;
    }
}