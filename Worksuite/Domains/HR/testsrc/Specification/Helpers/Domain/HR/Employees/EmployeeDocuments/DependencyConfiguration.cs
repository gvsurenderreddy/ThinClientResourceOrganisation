﻿using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Features.New;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeDocuments
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Rebind<IRequestHelper<NewEmployeeDocumentRequest>
                      , NewEmployeeDocumentRequestHelper>()
               .To<NewEmployeeDocumentRequestHelper>()
               ;
        }
    }
}