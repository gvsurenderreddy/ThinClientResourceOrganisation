using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.New
{
    public class NewSkillFixture
                    : NewReferenceDataFixture<Skill, CreateSkillRequest, CreateSkillResponse, ICreateSkill>
    {
        public NewSkillFixture( ICreateSkill the_command,
                                IRequestHelper<CreateSkillRequest> the_request_builder,
                                IEntityRepository<Skill> the_repository
                              )
                              : base(   the_command,
                                        the_request_builder,
                                        the_repository
                                    )
        {
        }
    }
}
