using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSummary;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel
{
    public class EmployeeDetailsViewModelBuilder
    {
        private readonly AViewModelBuilder view_Model_Builder;
        private readonly IGetEmployeeSummary employee_Sumary;

        public EmployeeDetailsViewModelBuilder
                    ( AViewModelBuilder the_view_model_builder
                    , IGetEmployeeSummary the_employee_sumary ) 
        {

            view_Model_Builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
            employee_Sumary = Guard.IsNotNull(the_employee_sumary, "the_employee_sumary");
           
        }

        public AViewModelBuilder For(EmployeeIdentity employee)
        {
            return view_Model_Builder.add_report(employee_Sumary.execute(employee).result);
        }
    }
}