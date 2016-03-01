using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New
{
    public class NewShiftTemplatesFixture
                          : ResponseCommandVerifiedByAnEntitiesStateFixture<NewShiftTemplatesRequest
                                                                            ,NewShiftTemplateResponse
                                                                            ,INewShiftTemplates
                                                                            ,PlannedSupply.ShiftTemplates.ShiftTemplate>
    {

        public override PlannedSupply.ShiftTemplates.ShiftTemplate entity
        {
            get
            {
                Guard.IsNotNull(response, "response");
                return repository
                    .Entities
                    .Single();
            }
        }


        public NewShiftTemplatesFixture(INewShiftTemplates the_command
                                        , IRequestHelper<NewShiftTemplatesRequest> the_request_builder
                                        , IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate> the_repository ) 
               : base (  the_command
                       , the_request_builder)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate> repository;
    }
}