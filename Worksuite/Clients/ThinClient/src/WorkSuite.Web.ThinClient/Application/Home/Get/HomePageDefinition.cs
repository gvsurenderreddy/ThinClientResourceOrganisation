using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;

namespace WTS.WorkSuite.Web.ThinClient.Application.Home.Get {

    public class HomePageDefinition 
                    : PageMetadataBuilder {
        
        protected override string page_id {
            get { return Resources.page_id; }
        }

        protected override void build_model_metadata
                                    ( IPageModelMetadataBuilder builder ) {

            builder
                .title( Resources.page_title )
                ;

        }

        protected override void build_bread_crumb_navigation_metadata
                                    ( IBreadCrumbNavigationMetadataBuilder bread_crumb_navigation_metadata_builder ) {

            bread_crumb_navigation_metadata_builder
                .for_page( Resources.page_id )
                .add_entry( Resources.page_id,
                            Resources.page_title
                          )
                ;
        }
    }
}