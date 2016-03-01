using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Presentation.Page
{
    public class ConfigureLocationsPresenter
                        : Presenter
    {
        public ActionResult Page()
        {
            var all_locations = _get_all_locations
                                    .execute()
                                    ;

            var view_model = _locations_list_builder
                                    .build(all_locations.result)
                                    ;

            return View(@"~\Views\HR\ReferenceData\Locations\Page.cshtml", view_model);
        }

        public ConfigureLocationsPresenter(IGetDetailsOfAllLocations the_get_all_locations,
                                           DetailsListBuilder<LocationDetails> the_locations_list_builder
                                          )
        {
            _get_all_locations = Guard.IsNotNull(the_get_all_locations, "the_get_all_locations");
            _locations_list_builder = Guard.IsNotNull(the_locations_list_builder, "the_locations_list_builder");
        }

        private readonly IGetDetailsOfAllLocations _get_all_locations;
        private readonly DetailsListBuilder<LocationDetails> _locations_list_builder;
    }
}