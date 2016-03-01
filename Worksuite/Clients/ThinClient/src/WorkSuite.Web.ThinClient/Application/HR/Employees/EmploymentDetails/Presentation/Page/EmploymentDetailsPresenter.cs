using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.ById;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmploymentDetails.Presentation.ViewModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmploymentDetails.Presentation.Page
{
    public class EmploymentDetailsPresenter : Presenter
    {
        public EmploymentDetailsPresenter(  IGetEmploymentDetailsById employmentDetailsQuery,
                                            EmploymentDetailsViewModelBuilder theModelBuilder
                                            )
        {
            _employmentDetailsById  = Guard.IsNotNull( employmentDetailsQuery, "employmentDetailsQuery" );
            _viewModelBuilder = Guard.IsNotNull( theModelBuilder, "theModelBuilder" );
        }

        public ActionResult Page( EmployeeIdentity employee )
        {
            
            var viewModel = _viewModelBuilder.For( employee )
                                             .add_report( _employmentDetailsById.execute( employee ).result )
                                             .build()
                                             ;

            return View(@"~\Views\HR\Employees\EmploymentDetails\Page.cshtml", viewModel);
        }

        private readonly IGetEmploymentDetailsById _employmentDetailsById;
        private readonly EmploymentDetailsViewModelBuilder _viewModelBuilder;
    }
}