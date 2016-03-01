using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New
{
    public class NewEmployeeSkillDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Bind<IGetNewEmployeeSkillRequest>()
               .To<GetNewEmployeeSkillRequest>()
               ;

            kernel
                .Bind<INewEmployeeSkill>()
                .To<NewEmployeeSkill>()
                ;

            kernel
              .Bind<INewEmployeeSkillValidator>()
              .To<NewEmployeeSkillValidator>()
              ;
        }
    }
}