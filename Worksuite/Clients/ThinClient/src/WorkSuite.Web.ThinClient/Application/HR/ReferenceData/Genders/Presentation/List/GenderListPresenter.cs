using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Genders.Presentation.List {

    public class GenderListPresenter
                    : Presenter{

        public ActionResult List () {
            var genders = get_all.execute();
            var view_model = list_builder.build( genders.result ) ;

            return View( @"~\Views\Shared\Views\DetailsList.cshtml", view_model );
        }


        public GenderListPresenter
                    ( IGetDetailsOfAllGenders get_all_query
                    , DetailsListBuilder<GenderDetails> the_list_builder ) {

            get_all = Guard.IsNotNull( get_all_query, "get_all_query" );
            list_builder = Guard.IsNotNull( the_list_builder, "the_list_builder" );

        }

        private readonly IGetDetailsOfAllGenders get_all;
        private readonly DetailsListBuilder<GenderDetails> list_builder;
    }
}