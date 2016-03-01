using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Fields.Description
{
    public class Description_is_restricted_to_the_default_maximum_number_of_characters
    {
        [TestClass]
        public class verify_on_create
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<  Skill,
                                                                                                            CreateSkillRequest,
                                                                                                            CreateSkillResponse,
                                                                                                            ICreateSkill,
                                                                                                            NewSkillFixture
                                                                                                         > { }


        [TestClass]
        public class verify_on_update
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<  Skill,
                                                                                                            UpdateSkillRequest,
                                                                                                            UpdateSkillResponse,
                                                                                                            IUpdateSkill,
                                                                                                            UpdateSkillFixture
                                                                                                          > { }
    }
}