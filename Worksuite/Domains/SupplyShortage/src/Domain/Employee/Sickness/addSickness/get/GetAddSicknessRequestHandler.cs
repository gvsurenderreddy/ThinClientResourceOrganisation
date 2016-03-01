using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.get
{
    public class GetAddSicknessRequestHandler : IGetAddSicknessRequestHandler
    {
        public GetAddSicknessResponse execute(GetAddSicknessRequest request)
        {
            return this
                .set_request(request)
                   .get_employee()
                   .build_response()
                  ;
        }

        private GetAddSicknessRequestHandler set_request(GetAddSicknessRequest request)
        {
            this.request = request;

            return this;
        }

        private GetAddSicknessRequestHandler get_employee()
        {
            Guard.IsNotNull(request, "request");

            employee_supply_shortage = employee_supply_shortage_repository.Entities.Single(e => e.employee_id == request.employee_id);

            return this;
        }

        private GetAddSicknessResponse build_response()
        {
            Guard.IsNotNull(employee_supply_shortage, "employee_supply_shortage");

            response_builder.set_response(new AddSicknessRequest
            {
                employee_id = employee_supply_shortage.employee_id
            });

            return response_builder.build();
        }

        public GetAddSicknessRequestHandler(IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository
                                                  , ServiceStatusResponseBuilder<AddSicknessRequest, GetAddSicknessResponse>
            response_builder)
        {
            this.employee_supply_shortage_repository = Guard.IsNotNull(employee_supply_shortage_repository, "employee_supply_shortage_repository");
            this.response_builder = Guard.IsNotNull(response_builder, "response_builder");
        }

        private EmployeeSupplyShortage employee_supply_shortage;
        private GetAddSicknessRequest request;

        private readonly IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository;
        private readonly ServiceStatusResponseBuilder<AddSicknessRequest, GetAddSicknessResponse> response_builder;

    }
}
