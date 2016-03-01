using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Presentation.Page {
    
    public class ConfigureTitlesPresenter : Presenter {
        private IGetDetailsOfAllTitles get_all;
        private DetailsListBuilder<TitleDetails> list_builder;

        public ActionResult Page () {
            var titles = get_all.execute();
            var view_model = list_builder.build( titles.result ) as DetailsList;

            return View( @"~\Views\HR\ReferenceData\Titles\Page.cshtml", view_model );
        }


        public ConfigureTitlesPresenter
            ( IGetDetailsOfAllTitles get_all_query
            , DetailsListBuilder<TitleDetails> the_list_builder ) {

            Guard.IsNotNull( get_all_query, "get_all_query" );
            Guard.IsNotNull( the_list_builder, "the_list_builder" );

            get_all = get_all_query;
            list_builder = the_list_builder;
        }

    }
}