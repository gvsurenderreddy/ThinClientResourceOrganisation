using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Presentation.List
{
    public class QualificationListPresenter
                        :   Presenter
    {
        public QualificationListPresenter(  IGetDetailsOfAllQualifications getAllQualificationsQuery,
                                            DetailsListBuilder<QualificationDetails> theQualificationDetailsListBuilder
                                         )
        {
            _getAllQualifications = Guard.IsNotNull(getAllQualificationsQuery, "getAllQualificationsQuery");
            _qualificationDetailsListBuilder = Guard.IsNotNull(theQualificationDetailsListBuilder, "theQualificationDetailsListBuilder");
        }

        public ActionResult List()
        {
            var response = _getAllQualifications.execute();
            var viewModel = _qualificationDetailsListBuilder.build( response.result );

            return View( @"~\Views\Shared\Views\DetailsList.cshtml", viewModel );
        }

        private readonly IGetDetailsOfAllQualifications _getAllQualifications;
        private readonly DetailsListBuilder<QualificationDetails> _qualificationDetailsListBuilder;
    }
}