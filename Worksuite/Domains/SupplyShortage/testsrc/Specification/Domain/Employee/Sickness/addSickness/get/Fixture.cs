using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.get;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Sickness.addSickness.get
{
    public class GetAddEmployeeSicknessRequestHandlerFixture
    {
        public GetAddSicknessResponse execute_command()
        {
            int new_employee_id = 1;

            request = new GetAddSicknessRequest { employee_id = new_employee_id };

            employee_supply_shortage_helper
                                .add()
                                .set_employee_id(new_employee_id)
                                ;

            return request_handler.execute(request);
        }


        public GetAddEmployeeSicknessRequestHandlerFixture()
        {
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
            request_handler = DependencyResolver.resolve<IGetAddSicknessRequestHandler>();
            employee_supply_shortage_helper = DependencyResolver.resolve<EmployeeSupplyShortageHelper>();
        }

        private readonly IGetAddSicknessRequestHandler request_handler;
        private readonly EmployeeSupplyShortageHelper employee_supply_shortage_helper;

        public GetAddSicknessRequest request;
        public FakeUnitOfWork unit_of_work { get; private set; }
    }
}
