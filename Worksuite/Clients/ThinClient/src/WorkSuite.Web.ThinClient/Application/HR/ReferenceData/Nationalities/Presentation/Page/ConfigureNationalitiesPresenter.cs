using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Presentation.Page
{
    public class ConfigureNationalitiesPresenter
                        : Presenter
    {
        public ConfigureNationalitiesPresenter( IGetDetailsOfAllNationalities the_query_to_get_all_nationalities,
                                                DetailsListBuilder< NationalityDetails > the_nationality_details_list_builder
                                              )
        {
            _get_all_nationalities = Guard.IsNotNull(   the_query_to_get_all_nationalities,
                                                        "the_query_to_get_all_nationalities"
                                                    );
            _nationality_details_list_builder = Guard.IsNotNull(    the_nationality_details_list_builder,
                                                                    "the_nationality_details_list_builder"
                                                                );
        }

        public ActionResult Page()
        {
            var response = _get_all_nationalities.execute();
            var view_model = _nationality_details_list_builder.build( response.result );

            return View(@"~\Views\HR\ReferenceData\Nationalities\Page.cshtml", view_model);
        }

        private readonly IGetDetailsOfAllNationalities _get_all_nationalities;
        private readonly DetailsListBuilder< NationalityDetails > _nationality_details_list_builder;
    }
}