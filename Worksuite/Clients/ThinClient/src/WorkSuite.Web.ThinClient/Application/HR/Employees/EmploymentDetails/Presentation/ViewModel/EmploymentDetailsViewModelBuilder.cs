using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSummary;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmploymentDetails.Presentation.ViewModel
{
    public class EmploymentDetailsViewModelBuilder
    {
        public EmploymentDetailsViewModelBuilder(   AViewModelBuilder viewModelBuilder,
                                                    IGetEmployeeSummary employeeSummary
                                                )
        {
            _viewModelBuilder   = Guard.IsNotNull( viewModelBuilder, "viewModelBuilder" );
            _employeeSummary = Guard.IsNotNull( employeeSummary, "employeeSummary" );
        }

        public AViewModelBuilder For( EmployeeIdentity employee )
        {
            return _viewModelBuilder.add_report( _employeeSummary.execute( employee ).result );
        }

        private readonly AViewModelBuilder _viewModelBuilder;
        private readonly IGetEmployeeSummary _employeeSummary;
    }
}