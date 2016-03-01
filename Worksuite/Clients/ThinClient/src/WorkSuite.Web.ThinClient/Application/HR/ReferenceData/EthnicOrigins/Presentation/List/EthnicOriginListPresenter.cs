using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Presentation.List
{
    public class EthnicOriginListPresenter
                        : Presenter
    {
        public ActionResult List()
        {
            var response = _get_details_of_all_ethnic_originals.execute();
            var view_model = _ethnic_original_details_list_builder.build( response.result );

            return View( @"~\Views\Shared\Views\DetailsList.cshtml", view_model );
        }

        public EthnicOriginListPresenter( IGetDetailsOfAllEthnicOrigins get_details_of_all_ethnic_originals,
                                            DetailsListBuilder< EthnicOriginDetails > ethnic_original_details_list_builder
                                          )
        {
            _get_details_of_all_ethnic_originals = Guard.IsNotNull( get_details_of_all_ethnic_originals, "get_details_of_all_ethnic_originals" );
            _ethnic_original_details_list_builder = Guard.IsNotNull( ethnic_original_details_list_builder, "ethnic_original_details_list_builder" );
        }

        private readonly IGetDetailsOfAllEthnicOrigins _get_details_of_all_ethnic_originals;
        private readonly DetailsListBuilder< EthnicOriginDetails > _ethnic_original_details_list_builder;
    }
}