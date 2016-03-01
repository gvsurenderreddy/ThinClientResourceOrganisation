using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees
{

    public class GetAllEmployeeDetails : IGetAllEmployeeDetails
    {

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAllEmployeeDetails" /> class.
        /// </summary>
        /// <param name="the_repository">The the_repository.</param>
        /// <param name="the_mapper">The the_mapper.</param>
        public GetAllEmployeeDetails
            (IQueryRepository<Employee> the_repository
            , IEmployeeDetailsDetailsMapper the_mapper)
        {

            Guard.IsNotNull(the_repository, "the_repository");
            Guard.IsNotNull(the_mapper, "the_mapper");

            repository = the_repository;
            mapper = the_mapper;
        }

        public GetAllEmployeeDetailsResponse execute()
        {
            var employee_to_details_map = mapper.Map.Compile();

            var all_emp = repository
                            .Entities
                            .OrderBy(e => e.surname)
                            .ToList()
                            .Select( employee_to_details_map );

            var return_object = new GetAllEmployeeDetailsResponse
            {
                messages = null,
                has_errors = false,
                result = all_emp,
            };

            return return_object;
        }

        private readonly IEmployeeDetailsDetailsMapper mapper;
        private readonly IQueryRepository<Employee> repository;


    }

}