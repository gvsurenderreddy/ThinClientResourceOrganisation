using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.List
{
    public class MaritalStatusListPresenter
                        :   Presenter
    {
        public MaritalStatusListPresenter(IGetDetailsOfAllMaritalStatuses getAllMaritalStatusesQuery,
                                    DetailsListBuilder< MaritalStatusDetails > theMaritalStatusDetailsListBuilder
                                 )
        {
            _getAllMaritalStatuses = Guard.IsNotNull( getAllMaritalStatusesQuery, "getAllMaritalStatusesQuery" );
            _MaritalStatusDetailsListBuilder = Guard.IsNotNull( theMaritalStatusDetailsListBuilder, "theMaritalStatusDetailsListBuilder" );
        }

        public ActionResult List()
        {
            var response = _getAllMaritalStatuses.execute();
            var viewModel = _MaritalStatusDetailsListBuilder.build( response.result );

            return View( @"~\Views\Shared\Views\DetailsList.cshtml", viewModel );
        }

        private readonly IGetDetailsOfAllMaritalStatuses _getAllMaritalStatuses;
        private readonly DetailsListBuilder< MaritalStatusDetails > _MaritalStatusDetailsListBuilder;
    }
}