using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Remove
{
    public class RemoveSkill
                    :   RemoveReferenceData< Skill, RemoveSkillRequest, RemoveSkillResponse >,
                        IRemoveSkill
    {
        public RemoveSkill( IUnitOfWork the_unit_of_work,
                            IEntityRepository< Skill > the_skill_repository
                          )
                :   base(   the_unit_of_work,
                            the_skill_repository
                        ) {}
    }
}
