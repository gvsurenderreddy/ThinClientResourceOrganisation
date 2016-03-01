using System;
using System.Globalization;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetAll;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.View.Page
{
    public class ViewOperationsCalendarsPresenter
                        : Presenter
    {
        public ActionResult Page()
        {
            GetAllOperationsCalendarsResponse all_operations_calendar_details = _get_all_operations_calendar_details.execute();

            _operations_calendar_details_model_metadata_builder
                            .id( Resources.page_id )
                            .field_id_extension( operationCalendar => operationCalendar.operations_calendar_id.ToString( CultureInfo.InvariantCulture ) )
                            .row_details_route_id( PlannedSupply.View.Page.Resources.page_id )
                            .row_details_route_pramameter_factory(oc => new { oc.operations_calendar_id })
                            ;

            displayTableView();

            var view_model = _operations_calendar_details_table_builder.build( all_operations_calendar_details.result );

            return View( @"~\Views\Operations\OperationalCalendars\View\Page.cshtml", view_model );
        }

        private void displayTableView()
        {
            _operations_calendar_details_field_metadata_builder
                                .for_field( oc => oc.calendar_name )
                                .id( "calendar_name" )
                                .lable( "Operations calendars" )
                                ;
        }

        public ViewOperationsCalendarsPresenter(    IGetAllOperationsCalendars the_get_all_operations_calendar_details,
                                                    ITableModelMetadataBuilder< OperationsCalendarDetails > the_operations_calendar_details_model_metadata_builder,
                                                    ITableFieldsMetadataBuilder< OperationsCalendarDetails > the_operations_calendar_details_field_metadata_builder,
                                                    TableBuilder< OperationsCalendarDetails > the_operations_calendar_details_table_builder
                                               )
        {
            _get_all_operations_calendar_details                = Guard.IsNotNull(  the_get_all_operations_calendar_details,
                                                                                    "the_get_all_operations_calendar_details"
                                                                                 );
            _operations_calendar_details_model_metadata_builder = Guard.IsNotNull(  the_operations_calendar_details_model_metadata_builder,
                                                                                    "the_operations_calendar_details_model_metadata_builder"
                                                                                 );
            _operations_calendar_details_field_metadata_builder = Guard.IsNotNull(  the_operations_calendar_details_field_metadata_builder,
                                                                                    "the_operations_calendar_details_field_metadata_builder"
                                                                                 );
            _operations_calendar_details_table_builder          = Guard.IsNotNull(  the_operations_calendar_details_table_builder,
                                                                                    "the_operations_calendar_details_table_builder"
                                                                                 );
        }

        private readonly IGetAllOperationsCalendars _get_all_operations_calendar_details;
        private readonly ITableModelMetadataBuilder< OperationsCalendarDetails > _operations_calendar_details_model_metadata_builder;
        private readonly ITableFieldsMetadataBuilder< OperationsCalendarDetails > _operations_calendar_details_field_metadata_builder;
        private readonly TableBuilder< OperationsCalendarDetails > _operations_calendar_details_table_builder;
    }
}