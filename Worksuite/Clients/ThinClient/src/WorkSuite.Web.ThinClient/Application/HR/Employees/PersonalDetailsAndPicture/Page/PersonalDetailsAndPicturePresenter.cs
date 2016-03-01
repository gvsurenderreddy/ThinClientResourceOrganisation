using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.GetById;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.ById;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.PersonalDetailsAndPicture.Page
{
    public class PersonalDetailsAndPicturePresenter : Presenter
    {
        public ActionResult Page(EmployeeIdentity employee)
        {
            var view_model = builder.For(employee)
                                     .add_report(personal_details.execute(employee).result)
                                     .add_report(image_details.execute(employee).result)
                                     .build();

            return View(@"~\Views\HR\Employees\PersonalDetailsAndPicture\Page.cshtml", view_model);
        }

        public PersonalDetailsAndPicturePresenter(IGetPersonalDetailsById personal_details_query,
                                                  IGetImageOfAnEmployee image_details_query,
                                                  EmployeeDetailsViewModelBuilder the_view_model_builder
                                                 )
        {
            personal_details = Guard.IsNotNull(personal_details_query, "personal_details_query");
            image_details = Guard.IsNotNull(image_details_query, "image_details_query");
            builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
        }

        private readonly IGetPersonalDetailsById personal_details;
        private readonly EmployeeDetailsViewModelBuilder builder;
        private readonly IGetImageOfAnEmployee image_details;
    }
}