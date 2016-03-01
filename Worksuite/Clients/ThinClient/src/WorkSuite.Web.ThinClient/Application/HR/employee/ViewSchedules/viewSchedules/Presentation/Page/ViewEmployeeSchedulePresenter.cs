using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.ViewSchedules.tableItems;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.ViewSchedules.viewSchedules.Presentation.Page
{
    public class ViewEmployeeSchedulePresenter :
        PageIdentityPresenter<ViewSchedulePageIdentity>
    {
        public ActionResult Page(EmployeeIdentity employee)
        {
            return this
                     .set_request( employee )
                     .add_details_table( )
                     .build_view( );
        }

         private ViewEmployeeSchedulePresenter set_request( EmployeeIdentity employee )
        {
            this.request = employee;

            return this;
        }

         private ViewEmployeeSchedulePresenter add_details_table()
          {
              Guard.IsNotNull(request, "request");

              response = query.execute(request);

              table_element = table_view_model_builder.build(response.result);

              return this;
          }

        private ActionResult build_view( )
        {
            Guard.IsNotNull(request, "request");

            var new_view_model = new EmployeeIdentityViewModel()
            {
                identity = request,
                view_elements = builder.For(request)
                                .add_view_element(table_element)
                                .build()
            };

             return
                View(
                    @"~\Application\HR\employee\ViewSchedules\viewSchedules\Presentation\Page\ViewSchedulePageView.cshtml",
                    new_view_model);

        }

        public ViewEmployeeSchedulePresenter(EmployeeDetailsViewModelBuilder the_view_model_builder,
            ViewSchedulePageIdentity page_identity,
            IGetEmployeeViewScheduleTableItems the_query,
            ICurrentPageIdentityRepository page_model_repository,
            ViewScheduleTableViewModelBuilder the_table_view_model_builder
            )
            : base(page_identity, page_model_repository)
        {
            builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
            query = Guard.IsNotNull(the_query, "the_query");
            table_view_model_builder = Guard.IsNotNull(the_table_view_model_builder, "the_table_view_model_builder");

        }

        private readonly EmployeeDetailsViewModelBuilder builder;
        private readonly IGetEmployeeViewScheduleTableItems query;
        private ViewScheduleTableViewModelBuilder table_view_model_builder;
        private GetEmployeeViewScheduleTableItemsResponse response;
        private EmployeeIdentity request;
        private IsAViewElement table_element;
    }

    public class ViewSchedulePageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}