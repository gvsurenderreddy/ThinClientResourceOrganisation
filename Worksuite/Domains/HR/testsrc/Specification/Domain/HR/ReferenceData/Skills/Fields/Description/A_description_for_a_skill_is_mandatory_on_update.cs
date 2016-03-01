using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Fields.Description
{
    [TestClass]
    public class A_description_for_a_skill_is_mandatory_on_update
                            :   A_description_is_mandatory_on_update<   Skill,
                                                                        UpdateSkillRequest,
                                                                        UpdateSkillResponse,
                                                                        IUpdateSkill,
                                                                        UpdateSkillFixture
                                                                    > {}
}