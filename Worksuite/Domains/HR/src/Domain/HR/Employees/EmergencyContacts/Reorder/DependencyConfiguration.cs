using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IGetReorderEmergencyContactRequest >()
                .To< GetReorderEmergencyContactRequest >()
                ;

            kernel
                .Bind< IReorderEmergencyContact >()
                .To< ReorderEmergencyContact >()
                ;

            kernel
                .Bind< ICanReorderEmergencyContact >()
                .To< CanReorderEmergencyContact >()
                ;
        }
    }
}