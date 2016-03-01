using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills
{
    public class DependencyConfiguration
                        :   ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            // Fake Skill repository
            kernel
              .Rebind<  IQueryRepository< Skill >,
                        IEntityRepository< Skill >,
                        FakeSkillRepository >()
              .To< FakeSkillRepository >()
              .InScope( x => scope )
              ;

            // Skill builder
            kernel
              .Rebind< ReferenceDataBuilder< Skill >,
                       SkillBuilder >()
              .To< SkillBuilder >()
              ;

            kernel
                .Rebind< IRequestHelper< CreateSkillRequest >,
                         NewSkillRequestHelper >()
                .To< NewSkillRequestHelper >()
                ;

            kernel
                .Rebind< IRequestHelper< UpdateSkillRequest >,
                        UpdateSkillRequestHelper >()
                .To< UpdateSkillRequestHelper >()
                ;

            kernel
                .Rebind< IRequestHelper< RemoveSkillRequest >,
                        RemoveSkillRequestHelper >()
                .To< RemoveSkillRequestHelper >()
                ;

        }
    }
}
