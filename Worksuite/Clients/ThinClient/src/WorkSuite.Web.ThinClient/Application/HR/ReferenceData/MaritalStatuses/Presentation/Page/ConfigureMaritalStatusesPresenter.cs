using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.Page
{
    public class ConfigureMaritalStatusesPresenter
                            : Presenter
    {
        public ConfigureMaritalStatusesPresenter(IGetDetailsOfAllMaritalStatuses getAllMaritalStatusesQuery,
                                            DetailsListBuilder<MaritalStatusDetails> theMaritalStatusDetailsListBuilder
                                       )
        {
            _getAllMaritalStatuses = Guard.IsNotNull(getAllMaritalStatusesQuery, "getAllMaritalStatusesQuery");
            _MaritalStatusDetailsListBuilder = Guard.IsNotNull(theMaritalStatusDetailsListBuilder, "theMaritalStatusDetailsListBuilder");
        }

        public ActionResult Page()
        {
            var response = _getAllMaritalStatuses.execute();
            var viewModel = _MaritalStatusDetailsListBuilder.build(response.result);

            return View(@"~\Views\HR\ReferenceData\MaritalStatuses\Page.cshtml", viewModel);
        }

        private readonly IGetDetailsOfAllMaritalStatuses _getAllMaritalStatuses;
        private readonly DetailsListBuilder<MaritalStatusDetails> _MaritalStatusDetailsListBuilder;
    }
}