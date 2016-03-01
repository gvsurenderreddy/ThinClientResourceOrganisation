using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills
{
    public class SkillIdentityHelper
    {
        public ReferenceDataIdentity get_identity()
        {
            return new ReferenceDataIdentity
            {
                id = _skill.id
            };
        }

        public SkillIdentityHelper()
        {
            _skill_helper = DependencyResolver.resolve<SkillHelper>();

            _skill = _skill_helper.add().description("C#").entity;
        }

        private Skill _skill;
        private SkillHelper _skill_helper;
    }
}