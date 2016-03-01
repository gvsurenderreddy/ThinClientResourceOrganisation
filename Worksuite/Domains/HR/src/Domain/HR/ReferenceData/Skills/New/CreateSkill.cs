using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.Create;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.New
{

    /// <summary>
    ///     Creates a new skill entry, if the request is valid
    /// </summary>

    public class CreateSkill
                :   CreateReferenceData<Skill, CreateSkillRequest, CreateSkillResponse>,
                    ICreateSkill
    {
        public CreateSkill( IUnitOfWork the_unit_of_work,
                            Validator the_validator,
                            IEntityRepository<Skill> the_repository
                          )
                          : base(   the_unit_of_work,
                                    the_validator,
                                    the_repository
                                )
        {
        }
    }
}
