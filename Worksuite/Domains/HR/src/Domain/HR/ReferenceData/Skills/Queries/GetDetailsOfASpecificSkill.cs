using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries
{
    /// <summary>
    ///     Implements the 'IGetDetailsOfASpecificSkill' interface
    ///     It will return a specific skill that is stored in the system.
    /// </summary>
    public class GetDetailsOfASpecificSkill
                        :   GetDetailsOfASpecificReferenceData< SkillDetails, Skill >,
                            IGetDetailsOfASpecificSkill
    {
        public GetDetailsOfASpecificSkill( IQueryRepository< Skill > the_repository )
                        :   base( the_repository ) {}
    }
}
