using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.details.Get {

    public class EmployeeDetailsPageViewModelBuilder {

        public IEnumerable<IsAViewElement> build
                                            ( EmployeeIdentity employee_identity ) {

            Guard.IsNotNull( employee_identity, "employee_identity" );


            return employee_details_view_model_builder
                    .For( employee_identity )
                    .add_view_element( options_grid_builder.build( employee_identity ))
                    .build()
                    ;
        }

        public EmployeeDetailsPageViewModelBuilder
                ( EmployeeDetailsOptionsViewModelBuilder options_grid_builder
                , EmployeeDetailsViewModelBuilder employee_details_view_model_builder ) {

            this.options_grid_builder = Guard.IsNotNull( options_grid_builder, "options_grid_builder" );
            this.employee_details_view_model_builder = Guard.IsNotNull( employee_details_view_model_builder, "employee_details_view_model_builder" );
        }

        private readonly EmployeeDetailsOptionsViewModelBuilder options_grid_builder;
        private readonly EmployeeDetailsViewModelBuilder employee_details_view_model_builder;
    }


    /// <summary>
    /// Create the view model for the employee details page
    /// </summary>
    public class EmployeeDetailsOptionsViewModelBuilder {


        public SectionedTileGrid build
                                  ( EmployeeIdentity employee_identity ) {

            return this
                    .set_employee( employee_identity )
                    .add_personal_information_section()
                    .add_other_information_section()
                    .add_options_section()
                    .build_view_model()
                    ;
        }


        public EmployeeDetailsOptionsViewModelBuilder
                ( StaticSectionedTileGridMetadataBuilder tile_grid_definition 
                , StaticSectionedTileGridBuilder tile_grid_builder
                , INamedRouteUrlBuilder route_builder
                , IContentRepository content_repository) {

            this.tile_grid_definition = Guard.IsNotNull( tile_grid_definition, "tile_grid_definition" );  
            this.tile_grid_builder = Guard.IsNotNull( tile_grid_builder, "tile_grid_builder" );  
            this.route_builder = Guard.IsNotNull( route_builder, "route_builder" );
            this.content_repository = Guard.IsNotNull(content_repository, "content_repository");
                }


        private EmployeeDetailsOptionsViewModelBuilder set_employee
                                                        ( EmployeeIdentity employee_identity ) {

            this.employee_identity = employee_identity;
            return this;
        }

        private EmployeeDetailsOptionsViewModelBuilder add_personal_information_section () {

            var personal_information_section = create_section( Resources.view_employees_personal_information ); 

            add_personal_details_and_picture_tile( personal_information_section );
            add_view_schedule_details_tile(personal_information_section);
            add_contact_details_and_addresses_tile( personal_information_section );
            add_emergency_contacts_tile( personal_information_section );

            personal_information_section.add();

            return this;
        }

        private EmployeeDetailsOptionsViewModelBuilder add_other_information_section () {

            var other_information_section = create_section( Resources.view_employees_other_details ); 

            add_notes_tile( other_information_section );
            add_employment_details_tile( other_information_section );
            add_documents_tile( other_information_section );
            add_skills_tile( other_information_section );
            add_qualifications_title( other_information_section );

            other_information_section.add();

            return this;
        }

        private EmployeeDetailsOptionsViewModelBuilder add_options_section () {

            var options_section = create_section( Resources.view_employees_options );

            add_holidays_tile( options_section );
            add_sickness_tile( options_section );
            add_remove_employee_tile( options_section );

            options_section.add();

            return this;
        }

        private SectionedTileGrid build_view_model () {

            return tile_grid_builder
                    .build( tile_grid_definition.build() )
                    ;
        }



        private void add_contact_details_and_addresses_tile
                       (  StaticTileGridSectionMetadataBuilder section ) {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile()
                .title( Employees.ContactDetailsAndAddresses.Page.Resources.page_title )
                .url( get_url( Employees.ContactDetailsAndAddresses.Page.Resources.page_id ))
                .add_class( "employee-contact-numbers-and-addresses" )
                .add()
                ;
        }

        private void add_documents_tile
                       (  StaticTileGridSectionMetadataBuilder section ) {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile()
                .title( Employees.EmployeeDocuments.Presentation.Page.Resources.page_title )
                .url( get_url(Employees.EmployeeDocuments.Presentation.Page.Resources.page_id ))
                .add_class( "employee-documents" )
                .add()
                ;
        }

        private void add_emergency_contacts_tile
                       ( StaticTileGridSectionMetadataBuilder section ) {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile()
                .title( Employees.EmergencyContacts.Presentation.Page.Resources.page_title )
                .url( get_url( Employees.EmergencyContacts.Presentation.Page.Resources.page_id ))
                .add_class( "employee-emergency-contacts" )
                .add()
                ;
        }

        private void add_employment_details_tile
                       ( StaticTileGridSectionMetadataBuilder section ) {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile()
                .title( Employees.EmploymentDetails.Presentation.Page.Resources.page_title )
                .url( get_url( Employees.EmploymentDetails.Presentation.Page.Resources.page_id ))
                .add_class( "employee-employment-details" )
                .add()
                ;
        }

        private void add_holidays_tile
                ( StaticTileGridSectionMetadataBuilder section )
        {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile( )
                .title(content_repository.get_resource_value("view_holidays_get_title"))
                .url(get_url(Holidays.viewHolidays.get.Resources.page_id))
                .add_class( "employee-holidays" )
                .add( )
                ;
        }

        private void add_sickness_tile
               (StaticTileGridSectionMetadataBuilder section)
        {

            Guard.IsNotNull(section, "section");

            section
                .new_tile()
               .title(content_repository.get_resource_value("view_sickness_get_title"))
                 .url(get_url(Sickness.viewSickness.get.Resources.page_id))
                .add_class("employee-sickness")
                .add()
                ;
        }

        private void add_notes_tile
                       ( StaticTileGridSectionMetadataBuilder section ) {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile()
                .title( Employees.Notes.Presentation.Page.Resources.page_title )
                .url( get_url( Employees.Notes.Presentation.Page.Resources.page_id ))
                .add_class( "employee-notes" )
                .add()
                ;
        }

        private void add_personal_details_and_picture_tile
                       ( StaticTileGridSectionMetadataBuilder section ) {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile()
                .title( Employees.PersonalDetailsAndPicture.Page.Resources.page_title )
                .url( get_url( Employees.PersonalDetailsAndPicture.Page.Resources.page_id ))
                .add_class( "employee-personal-details-and-picture" )
                .add()
                ;
        }

        private void add_view_schedule_details_tile
                     (StaticTileGridSectionMetadataBuilder section)
        {

            Guard.IsNotNull(section, "section");

            section
                .new_tile()
                .title(ViewSchedules.viewSchedules.get.Resources.page_title)
                 .url(get_url(ViewSchedules.viewSchedules.Presentation.Page.Resources.page_id))
                .add_class("view-employee-schedule")
                .add()
                ;
        }

        private void add_qualifications_title
                        ( StaticTileGridSectionMetadataBuilder section ) {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile()
                .title( Employees.EmployeeQualifications.Presentation.Page.Resources.page_title )
                .url( get_url( Employees.EmployeeQualifications.Presentation.Page.Resources.page_id ))
                .add_class( "employee-qualifications" )
                .add()
                ;
        }

        private void add_remove_employee_tile
                        ( StaticTileGridSectionMetadataBuilder section ) {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile()
                .title( Employees.Remove.Presentation.Page.Resources.page_title )
                .url( get_url( Employees.Remove.Presentation.Page.Resources.page_id ))
                .add_class( "employee-remove-employee" )
                .add()
                ;
        }


        private void add_skills_tile
                       ( StaticTileGridSectionMetadataBuilder section ) {

            Guard.IsNotNull( section, "section" );

            section
                .new_tile()
                .title( Employees.EmployeeSkills.Presentation.Page.Resources.page_title )
                .url( get_url( Employees.EmployeeSkills.Presentation.Page.Resources.page_id ))
                .add_class( "employee-skills" )
                .add()
                ;
        }


        private StaticTileGridSectionMetadataBuilder create_section
                                                       ( string section_title ) {

            return tile_grid_definition
                     .new_section( section_title )
                     ;
        }

        private string get_url
                        ( string the_route_name ) {

            Guard.IsNotNull( employee_identity, "employee_identity" );


            return route_builder.build( new NamedRouteUrlObjectBuildDefinition {
                route_name = the_route_name,
                route_parameters_factory = () => new { employee_identity.employee_id }
            });
        }


        private EmployeeIdentity employee_identity;

        private readonly StaticSectionedTileGridMetadataBuilder tile_grid_definition;
        private readonly StaticSectionedTileGridBuilder tile_grid_builder;
        private readonly INamedRouteUrlBuilder route_builder;
        private readonly IContentRepository content_repository;
    }
}