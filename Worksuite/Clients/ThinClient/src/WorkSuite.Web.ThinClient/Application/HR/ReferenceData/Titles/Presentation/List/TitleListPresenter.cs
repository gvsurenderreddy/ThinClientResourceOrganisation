using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Presentation.List
{
    public class TitleListPresenter
                    : Presenter{

        public ActionResult List () {
            var titles = get_all.execute();
            var view_model = list_builder.build( titles.result ) ;

            return View( @"~\Views\Shared\Views\DetailsList.cshtml", view_model );
        }


        public TitleListPresenter
                    ( IGetDetailsOfAllTitles get_all_query
                    , DetailsListBuilder<TitleDetails> the_list_builder ) {

            get_all = Guard.IsNotNull( get_all_query, "get_all_query" );
            list_builder = Guard.IsNotNull( the_list_builder, "the_list_builder" );

        }

        private readonly IGetDetailsOfAllTitles get_all;
        private readonly DetailsListBuilder<TitleDetails> list_builder;
    }
}