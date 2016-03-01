using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries
{
    /// <summary>
    ///     Implements the 'IGetDetailsOfAllSkills' interface
    ///     It will return all skills that are stored in the system.
    /// </summary>
    public class GetDetailsOfAllSkills
        :   GetDetailsOfAllReferenceData< Skill, SkillDetails >,
            IGetDetailsOfAllSkills
    {
        public GetDetailsOfAllSkills( IQueryRepository< Skill > the_repository )
            :   base( the_repository ) {}
    }
}
