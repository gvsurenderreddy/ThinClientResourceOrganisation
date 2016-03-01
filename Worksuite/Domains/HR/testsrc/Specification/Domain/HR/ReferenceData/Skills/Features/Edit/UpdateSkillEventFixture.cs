using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Edit
{
    public class UpdateSkillEventFixture
                        : UpdateReferenceDataEventFixture<Skill,
                                                        UpdateSkillRequest,
                                                        UpdateSkillResponse,
                                                        IUpdateSkill,
                                                        SkillUpdatedEvent
                                                   >
    {
        public UpdateSkillEventFixture(IUpdateSkill the_command,
                                            IRequestHelper<UpdateSkillRequest> the_request_builder,
                                            IEntityRepository<Skill> the_repository,
                                            FakeEventPublisher<SkillUpdatedEvent> the_events_publisher
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository,
                    the_events_publisher
                  ) { }
    }

}