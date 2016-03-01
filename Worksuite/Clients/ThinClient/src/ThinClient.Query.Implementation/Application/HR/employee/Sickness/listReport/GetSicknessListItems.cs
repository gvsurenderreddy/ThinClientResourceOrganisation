using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listItems;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listReport
{
    public class GetSicknessListItems : IGetSicknessListItems
    {
        public GetSicknessListItemsResponse execute(EmployeeIdentity request)
        {
            var result = sickness_list_report_repository.Entities
                    .Where(e => e.employee_id == request.employee_id)
                    .OrderBy(d => d.sickness_date)
                    .ToList()
                    .Select(item => new SicknessListItem
                    {
                       employee_id = item.employee_id,
                       sickness_date_display = item.sickness_date.FormatForReport(),
                       sickness_date = item.sickness_date
                    })
                    ;

            var response = new GetSicknessListItemsResponse
            {
                has_errors = false,
                messages = null,
                result = result
            };

            return response;
        }

        public GetSicknessListItems(IQueryRepository<SicknessListView> sickness_list_report_repository)
        {
            this.sickness_list_report_repository = Guard.IsNotNull(sickness_list_report_repository, "sickness_list_report_repository");
        }

        private readonly IQueryRepository<SicknessListView> sickness_list_report_repository;
    }
}
