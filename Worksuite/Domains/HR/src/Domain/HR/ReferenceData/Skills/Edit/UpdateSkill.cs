using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit
{
    public class UpdateSkill
                        : UpdateReferenceData<Skill, UpdateSkillRequest, UpdateSkillResponse, SkillUpdatedEvent>,
                            IUpdateSkill
    {
        public UpdateSkill(IUnitOfWork the_unit_of_work,
                            IEntityRepository<Skill> the_repository,
            IEventPublisher<SkillUpdatedEvent> the_event_publisher,
                            Validator the_validator
                          )
            : base(the_unit_of_work,
                        the_repository,
                        the_event_publisher,
                        the_validator
                    ) { }
    }
}
