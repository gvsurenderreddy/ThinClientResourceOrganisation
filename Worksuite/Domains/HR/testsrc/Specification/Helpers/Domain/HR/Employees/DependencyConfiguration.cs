using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Remove;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees
{

    public class DependencyConfiguration : ADependencyConfiguration
    {

        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Rebind<IQueryRepository<Employee>
                         , IEntityRepository<Employee>
                         , FakeEmployeeRepository>()
                .To<FakeEmployeeRepository>()
                .InScope(x => scope)
                ;

            kernel
                .Rebind<IRequestHelper<UpdateEmployeePersonalDetailsRequest>
                       , UpdateRequestHelper>()
                .To<UpdateRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<WorkSuite.HR.HR.Employees.EmployeeImage.Edit.UpdateRequest>
                       , Services.Domain.HR.Employees.EmployeeImage.Features.Edit.UpdateRequestHelper>()
                .To<Services.Domain.HR.Employees.EmployeeImage.Features.Edit.UpdateRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<EmployeeIdentity>
                       , RemoveRequestHelper>()
                .To<RemoveRequestHelper>()
                ;

           
        }

    }

}