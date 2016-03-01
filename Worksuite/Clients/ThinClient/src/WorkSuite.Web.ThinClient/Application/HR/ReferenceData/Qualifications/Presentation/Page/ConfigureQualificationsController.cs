using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Presentation.Page
{
    public class ConfigureQualificationsController
                        :   Presenter
    {
        public ConfigureQualificationsController(   IGetDetailsOfAllQualifications getDetailsOfAllQualificationsQuery,
                                                    DetailsListBuilder< QualificationDetails > theQualificationDetailsListBuilder
                                                )
        {
            _getAllQualifications = Guard.IsNotNull(getDetailsOfAllQualificationsQuery, "getDetailsOfAllQualificationsQuery");
            _qualificationDetailsListBuilder = Guard.IsNotNull(theQualificationDetailsListBuilder, "theQualificationDetailsListBuilder");
        }

        public ActionResult Page()
        {
            var response = _getAllQualifications.execute();
            var viewModel = _qualificationDetailsListBuilder.build( response.result );

            return View(@"~\Views\HR\ReferenceData\Qualifications\Page.cshtml", viewModel);
        }

        private readonly IGetDetailsOfAllQualifications _getAllQualifications;
        private readonly DetailsListBuilder< QualificationDetails > _qualificationDetailsListBuilder;

    }
}