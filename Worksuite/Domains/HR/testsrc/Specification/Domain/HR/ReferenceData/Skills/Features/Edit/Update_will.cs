using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Edit
{
    [TestClass]
    public class Update_will
                    :   CommandCommitedChangesSpecification< UpdateSkillRequest, UpdateSkillResponse, UpdateSkillFixture > {}

    [TestClass]
    public class command_will : ReferenceDataUpdatedEventSpecification<Skill,
                                                                        UpdateSkillRequest,
                                                                        UpdateSkillResponse,
                                                                        IUpdateSkill,
                                                                        SkillUpdatedEvent,
                                                                        UpdateSkillEventFixture>
    {

    }
}
