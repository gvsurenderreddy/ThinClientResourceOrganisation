using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.TileGrids._1;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Tiles._1;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.Home.Get {
    
    
    /// <summary>
    /// Creates the view model for the home page
    /// </summary>
    public class HomePageViewModelBuilder
    {

        private IContentRepository content_repository;

        public HomePageViewModelBuilder(IContentRepository the_content_repository)
        {
            content_repository = Guard.IsNotNull(the_content_repository, "the_content_repository");
        }

        public TileGridViewModel build () {

            var grid_builder = new TileGridViewModelBuilder();

            return grid_builder
                        .add_section( manage_employees_section() )
                        .add_section( manage_operations_section() )
                        .add_section( shift_and_shift_break_templates_section() )
                        .add_section( setup_options_section() )
                        .build()
                        ;
        }

        private TileGridSectionViewModel manage_employees_section () {

            var section_builder = new TileGridSectionViewModelBuilder();

            return section_builder
                    .title( Resources.manage_employees_section_title )
                    .add_tile( add_new_employee_tile() ) 
                    .add_tile( view_employees_tile() )
                    .build()
                    ;
        }

        private TileGridSectionViewModel manage_operations_section () {

            var section_builder = new TileGridSectionViewModelBuilder();

            return section_builder
                    .title( Resources.manage_operations_section_title )
                    .add_tile( add_new_operations_calendar_tile() )
                    .add_tile( view_operations_calendars_tile() )
                    .build()
                    ;
        }

        private TileGridSectionViewModel shift_and_shift_break_templates_section () {

            var section_builder = new TileGridSectionViewModelBuilder();

            return section_builder
                    .title( Resources.shifts_and_break_templates_section_title )
                    .add_tile( add_new_shift_template_tile() )
                    .add_tile( view_shift_templates_tile() )
                    .add_tile( add_new_break_template_tile() )
                    .add_tile( view_break_template_tile() )
                    .build()
                    ;
        }

        private TileGridSectionViewModel setup_options_section () {

            var section_builder = new TileGridSectionViewModelBuilder();

            return section_builder
                    .title( Resources.setup_options_section_title )
                    .add_tile( setup_menues_tile() )
                    .build()
                    ;
        }
      

        private TileViewModel add_new_employee_tile () {

            var tile_builder = new TileViewModelBuilder();

            return tile_builder
                        .title(content_repository.get_resource_value("add_new_employee_page_resource_title"))
                        .route_name( HR.Employees.addNewEmployee.page.Resources.page_id )
                        .build()
                        ;
        }
        private TileViewModel view_employees_tile () {

            var tile_builder = new TileViewModelBuilder();

            return tile_builder
                        .title( HR.Employees.viewEmployees.get.Resources.page_title )
                        .route_name( HR.Employees.viewEmployees.get.Resources.page_id )
                        .build()
                        ;
        }

        private TileViewModel add_new_operations_calendar_tile () {

            var tile_builder = new TileViewModelBuilder();

            return tile_builder
                        .title( Operations.OperationalCalendars.New.Presentation.Page.Resources.page_title )
                        .route_name( Operations.OperationalCalendars.New.Presentation.Page.Resources.page_id )
                        .build()
                        ;
        }
        private TileViewModel view_operations_calendars_tile () {

            var tile_builder = new TileViewModelBuilder();

            return tile_builder
                    .title( Operations.OperationalCalendars.View.Page.Resources.page_title )
                    .route_name( Operations.OperationalCalendars.View.Page.Resources.page_id )
                    .build()
                    ;
        }

        private TileViewModel add_new_shift_template_tile () {

            var tile_builder = new TileViewModelBuilder();

            return tile_builder
                    .title( SetupOptions.ShiftTemplates.Presentation.New.Page.Resources.page_title )
                    .route_name( SetupOptions.ShiftTemplates.Presentation.New.Page.Resources.page_id )
                    .build()
                    ;
        }
        private TileViewModel view_shift_templates_tile () {

            var tile_builder = new TileViewModelBuilder();

            return tile_builder
                    .title( SetupOptions.ShiftTemplates.Presentation.View.Page.Resources.page_title )
                    .route_name( SetupOptions.ShiftTemplates.Presentation.View.Page.Resources.page_id )
                    .build()
                    ;
        }

        private TileViewModel add_new_break_template_tile () {

            var tile_builder = new TileViewModelBuilder();

            return tile_builder
                    .title( SetupOptions.BreakTemplates.Presentation.New.Page.Resources.page_title )
                    .route_name( SetupOptions.BreakTemplates.Presentation.New.Page.Resources.page_id )
                    .build()
                    ;
        }
        private TileViewModel view_break_template_tile () {

            var tile_builder = new TileViewModelBuilder();

            return tile_builder
                    .title( SetupOptions.BreakTemplates.Presentation.ViewAll.Page.Resources.page_title )
                    .route_name( SetupOptions.BreakTemplates.Presentation.ViewAll.Page.Resources.page_id )
                    .build()
                    ;
        }

        private TileViewModel setup_menues_tile () {

            var tile_builder = new TileViewModelBuilder();

            return tile_builder
                    .title( HR.setupMenus.Get.Resources.page_title )
                    .route_name( HR.setupMenus.Get.Resources.page_id )
                    .build()
                    ;
        }
    }
}