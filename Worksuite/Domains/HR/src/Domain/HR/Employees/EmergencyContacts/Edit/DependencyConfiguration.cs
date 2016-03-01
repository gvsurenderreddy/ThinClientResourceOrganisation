using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Bind<IGetUpdateRequest>()
                .To<GetUpdateEmergencyContactRequest>()
                ;

            kernel
                .Bind<IUpdate>()
                .To<UpdateEmergencyContact>()
                ;

            kernel
                .Bind<ICanUpdateEmergencyContact>()
                .To<CanUpdateEmergencyContact>()
                ;
        }
    }
}