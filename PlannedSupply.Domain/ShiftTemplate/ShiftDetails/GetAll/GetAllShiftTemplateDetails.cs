using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplate.ShiftDetails.Mapper;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.GetAll;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.ShiftDetails.GetAll
{
    public class GetAllShiftTemplateDetails 
                      : IGetAllShiftTemplates
    {
        public GetAllShiftTemplateResponse execute()
        {
            var entity = repository
                .Entities
                .OrderBy(x => x.shift_title)
                .ToList()
                .Select(shift_temmplate_mapper.Map.Compile());

         return new GetAllShiftTemplateResponse()
         {
             messages = null,
             has_errors = false,
             result = entity
         };

        }

        public GetAllShiftTemplateDetails
                        (IQueryRepository<ShiftTemplates.ShiftTemplate> the_repository
                        , IShiftTemplatesDetailsMapper the_shift_temmplate_mapper)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
            shift_temmplate_mapper = Guard.IsNotNull(the_shift_temmplate_mapper, "the_shift_temmplate_mapper");
        }

        private readonly IQueryRepository<ShiftTemplates.ShiftTemplate> repository;
        private readonly IShiftTemplatesDetailsMapper shift_temmplate_mapper;
    }
}