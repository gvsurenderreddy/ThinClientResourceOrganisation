using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.listItems;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel;
using WTS.WorkSuite.Web.ThinClient.Infrastructure;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.viewHolidays.get
{
    public class ViewHolidaysPagePresenter : PageIdentityPresenter<ViewHolidaysPageIdentity>
    {

        public ActionResult Page( EmployeeIdentity request )
        {
            return this
                     .set_request( request )
                     .set_execute( )
                     .build_view( );
        }

        private ViewHolidaysPagePresenter set_request( EmployeeIdentity request )
        {
            this.request = request;

            return this;
        }

        private ViewHolidaysPagePresenter set_execute( )
        {
            Guard.IsNotNull( request, "request" );

            list_response = get_holiday_list_items.execute(request);
            return this;
        }

        private ActionResult build_view( )
        {
            Guard.IsNotNull( request, "request" );

            var view_model = new EntityIdentityViewModel<EmployeeIdentity>
            {
                identity = request,
                view_elements = builder.For(request)
                                .add_details_list(list_response.result)
                                .build()
            };

            return View( @"~\Application\HR\employee\Holidays\viewHolidays\get\ViewHolidaysPageView.cshtml", view_model );

        }

        public ViewHolidaysPagePresenter(
                                          ViewHolidaysPageIdentity page_identity
                                        , ICurrentPageIdentityRepository page_model_repository
                                        , IGetHolidayListItems get_holiday_list_items
                                        , EmployeeDetailsViewModelBuilder builder)
            : base( page_identity, page_model_repository )
        {
            this.get_holiday_list_items = Guard.IsNotNull(get_holiday_list_items, "get_holiday_list_items");
            this.builder = Guard.IsNotNull(builder, "builder");
        }

        private readonly IGetHolidayListItems get_holiday_list_items;
        private EmployeeIdentity request;
        private readonly EmployeeDetailsViewModelBuilder builder;
        private GetHolidayListItemsResponse list_response;

    }
}