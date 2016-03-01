using System;
using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit
{
    public class UpdateShiftTemplateFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture< UpdateShiftTemplateRequest
                                                                      ,UpdateShiftTemplateResponse
                                                                      ,IUpdateShiftTemplate
                                                                      ,PlannedSupply.ShiftTemplates.ShiftTemplate>
    {
        public override PlannedSupply.ShiftTemplates.ShiftTemplate entity
        {
            get
            {
           
            
            var hour = System.Convert.ToInt32(request.start_time.hours);
            var minute = System.Convert.ToInt32(request.start_time.minutes);
            var time_in_second = hour*60*60 + minute*60;

            var duration_hour = System.Convert.ToInt32(request.duration.hours);
            var duration_minute = System.Convert.ToInt32(request.duration.minutes);
            var duration_in_second = duration_hour * 60 * 60 + duration_minute * 60;

               var colour = new RgbColour(System.Convert.ToByte(request.colour.R), System.Convert.ToByte(request.colour.G),
                    System.Convert.ToByte(request.colour.B)).ToString();

                return repository
                    .Entities
                    .Single(x => x.id == request.shift_template_id 
                           && x.shift_title == request.shift_title 
                           && x.start_time_in_seconds_from_midnight ==time_in_second 
                           && x.duration_in_seconds == duration_in_second 
                           && x.colour == colour);
            }
        }

        public UpdateShiftTemplateFixture
                           ( IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate> the_repository 
                           , IUpdateShiftTemplate the_command
                           , IRequestHelper<UpdateShiftTemplateRequest> the_request_builder) 
                           : base(the_command, the_request_builder)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }


        private readonly IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate> repository;

    }
}