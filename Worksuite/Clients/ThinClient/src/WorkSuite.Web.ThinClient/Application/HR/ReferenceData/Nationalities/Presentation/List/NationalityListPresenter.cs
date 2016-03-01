using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Presentation.List
{
    public class NationalityListPresenter
                        : Presenter
    {
        public ActionResult List()
        {
            var response = _get_all_nationalities.execute();
            var view_model = _nationality_details_list_builder.build( response.result );

            return View( @"~\Views\Shared\Views\DetailsList.cshtml" , view_model );
        }

        public NationalityListPresenter(    IGetDetailsOfAllNationalities get_all_nationalities_query,
                                            DetailsListBuilder< NationalityDetails > nationality_details_list_builder
                                       )
        {
            _get_all_nationalities = Guard.IsNotNull( get_all_nationalities_query, "get_all_nationalities_query" );
            _nationality_details_list_builder = Guard.IsNotNull( nationality_details_list_builder,
                "nationality_details_list_builder" );
        }

        private readonly IGetDetailsOfAllNationalities _get_all_nationalities;
        private readonly DetailsListBuilder< NationalityDetails > _nationality_details_list_builder;
    }
}