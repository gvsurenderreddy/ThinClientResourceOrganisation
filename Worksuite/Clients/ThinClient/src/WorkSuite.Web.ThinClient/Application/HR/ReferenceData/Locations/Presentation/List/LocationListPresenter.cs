using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Presentation.List
{
    public class LocationListPresenter
                    : Presenter
    {
        public ActionResult List()
        {
            var all_locations = _get_all_locations
                                    .execute()
                                    ;

            var view_model = _location_details_list_builder
                                    .build(all_locations.result)
                                    ;

            return View(@"~\Views\Shared\Views\DetailsList.cshtml", view_model);
        }

        public LocationListPresenter(IGetDetailsOfAllLocations the_get_all_locations,
                                     DetailsListBuilder<LocationDetails> the_location_details_list_builder
                                    )
        {
            _get_all_locations = Guard.IsNotNull(the_get_all_locations, "the_get_all_locations");
            _location_details_list_builder = Guard.IsNotNull(the_location_details_list_builder,
                                                             "the_location_details_list_builder"
                                                            );
        }

        private readonly IGetDetailsOfAllLocations _get_all_locations;
        private readonly DetailsListBuilder<LocationDetails> _location_details_list_builder;
    }
}