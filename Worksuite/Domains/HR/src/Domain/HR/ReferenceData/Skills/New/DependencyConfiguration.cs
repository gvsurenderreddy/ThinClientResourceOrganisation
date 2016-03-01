using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.GetCreateRequest;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.New
{
    public class DependencyConfiguration
                            :   ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind< ICreateSkill >()
                .To < CreateSkill >()
                ;

            kernel
                .Bind< IGetCreateSkillRequest >()
                .To< GetCreateSkillRequest >()
                ;
        }
    }
}
