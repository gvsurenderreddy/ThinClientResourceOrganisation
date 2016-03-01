using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit
{
    public class DependencyConfiguration
                        :   ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IUpdateSkill >()
                .To< UpdateSkill >()
                ;

            kernel
                .Bind< IGetUpdateSkillRequest >()
                .To< GetUpdateSkillRequest >()
                ;
        }
    }
}
