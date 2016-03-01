using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listItems;
using WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.listItems.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.listItems
{
    public class GetSicknessListItemsFixture
    {
        public void execute_query()
        {
            Guard.IsNotNull(request, "request");

            response = get_employee_sickness_list_items.execute(request);
        }

        public void set_request(EmployeeIdentity request)
        {
            this.request = request;
        }

        public SicknessListViewBuilder add()
        {
            return employee_sickness_list_view_helper.add();
        }
        public GetSicknessListItemsFixture(SicknessListViewHelper employee_sickness_list_view_helper
                                                 , IGetSicknessListItems get_employee_sickness_list_items)
        {
            this.employee_sickness_list_view_helper = Guard.IsNotNull(employee_sickness_list_view_helper, "employee_sickness_list_view_helper");
            this.get_employee_sickness_list_items = Guard.IsNotNull(get_employee_sickness_list_items, "get_employee_sickness_list_items");
        }

        private readonly SicknessListViewHelper employee_sickness_list_view_helper;
        private readonly IGetSicknessListItems get_employee_sickness_list_items;
        
        private EmployeeIdentity request;
        public GetSicknessListItemsResponse response { private set; get; }

    }
}
