using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Bind<IGetNewEmergencyContactRequest>()
               .To<GetNewEmergencyContactRequest>()
               ;

            kernel
                .Bind<INewEmergencyContact>()
                .To<NewEmergencyContact>()
                ;

            kernel
               .Bind<ICanAddNewEmergencyContact>()
               .To<CanAddNewEmergencyContact>()
               ;

            kernel
              .Bind<INewEmergencyContactValidator>()
              .To<NewEmergencyContactValidator>()
              ;
        }
    }
}