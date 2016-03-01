using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.TileGrids._1;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Tiles._1;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.setupMenus.Get {

    /// <summary>
    /// Create the view model for the setup-menus page
    /// </summary>
    public class SetupMenusPageViewModelBuilder {


        public TileGridViewModel build () {
            
            return ( new TileGridViewModelBuilder() )
                    .add_section( personal_information_section() )
                    .add_section( other_information_section() )
                    .build()
                    ;
        }


        private TileGridSectionViewModel other_information_section () {
         
            return ( new TileGridSectionViewModelBuilder() )
                    .title( Resources.view_employees_other_details )
                    .add_tile( job_titles_tile() )
                    .add_tile( skills_tile() )
                    .add_tile( qualifications_tile() )
                    .add_tile( locations_title() )
                    .build()
                    ;

        }
        private TileGridSectionViewModel personal_information_section () {
            
            return ( new TileGridSectionViewModelBuilder() )
                    .title( Resources.view_personal_details_section_title  )
                    .add_tile( titles_tile() )
                    .add_tile( genders_tile() )
                    .add_tile( relationships_tile() )
                    .add_tile( nationalities_tile() )
                    .add_tile( marital_status_tile() )
                    .add_tile( ethnic_origin_tile() )
                    .build()
                    ;
        }


        private TileViewModel ethnic_origin_tile () {
            
            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.EthnicOrigins.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.EthnicOrigins.Presentation.Page.Resources.page_id )
                    .build()
                    ;
        }
        private TileViewModel genders_tile () {
            
            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.Genders.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.Genders.Presentation.Page.Resources.page_id )
                    .build()
                    ;
        }
        private TileViewModel job_titles_tile () {
            
            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.JobTitles.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.JobTitles.Presentation.Page.Resources.page_id )
                    .build()
                    ;
        }
        private TileViewModel locations_title () {
            
            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.Locations.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.Locations.Presentation.Page.Resources.page_id )
                    .build()
                    ;

        }
        private TileViewModel marital_status_tile () {

            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.MaritalStatuses.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.MaritalStatuses.Presentation.Page.Resources.page_id )
                    .build()
                    ;            
        }
        private TileViewModel nationalities_tile () {
            
            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.Nationalities.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.Nationalities.Presentation.Page.Resources.page_id )
                    .build()
                    ;
        }
        private TileViewModel qualifications_tile () {
            
            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.Qualifications.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.Qualifications.Presentation.Page.Resources.page_id )
                    .build()
                    ;
        }
        private TileViewModel relationships_tile () {
            
            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.Relationships.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.Relationships.Presentation.Page.Resources.page_id )
                    .build()
                    ;

        }
        private TileViewModel skills_tile () {
            
            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.Skills.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.Skills.Presentation.Page.Resources.page_id )
                    .build()
                    ;

        }
        private TileViewModel titles_tile () {
            
            return ( new TileViewModelBuilder() )
                    .title( ReferenceData.Titles.Presentation.Page.Resources.page_title )
                    .route_name( ReferenceData.Titles.Presentation.Page.Resources.page_id )
                    .build()
                    ;
        }


    }
}