using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmergencyContacts
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Rebind<IRequestHelper<NewEmergencyContactRequest>, NewEmergencyContactRequestHelper>()
                    .To<NewEmergencyContactRequestHelper>();

            kernel.Rebind<IRequestHelper<UpdateRequest>, UpdateRequestHelper>()
                    .To<UpdateRequestHelper>();
        }
    }
}