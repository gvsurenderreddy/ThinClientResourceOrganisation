using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.ById;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails {

    public class PersonalDetailsDependencyConfiguration : ADependencyConfiguration {

        public override void configure ( IKernel kernel, Func<IContext, object> scope ) {
            
            kernel
                .Bind<IGetPersonalDetailsById>(  )
                .To<GetPersonalDetailsById>()
                ;

            kernel
                .Bind<IGetUpdateEmployeePersonalDetailsRequest>(  )
                .To<GetUpdateEmployeePersonalDetailsRequest>()
                ;

            kernel
                .Bind<IUpdateEmployeePersonalDetails>()
                .To<Edit.UpdateEmployeePersonalDetails>()
                ;

            kernel
                .Bind<ICanUpdatePersonalDetails>()
                .To<CanUpdatePersonalDetails>()
                ;

        }

    }

}