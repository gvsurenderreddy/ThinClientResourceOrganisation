using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.ById;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.ContactDetails {

    public class ContactDetailsDependencyConfiguration : ADependencyConfiguration 
    {

        public override void configure ( IKernel kernel, Func<IContext, object> scope ) 
        {
            
            kernel
                .Bind<IGetContactDetailsById>(  )
                .To<GetContactDetailsById>()
                ;

            kernel
                .Bind<IGetUpdateRequest>(  )
                .To<GetUpdateContactDetailsRequest>()
                ;

            kernel
                .Bind<IUpdate>()
                .To<Edit.UpdateContactDetails>()
                ;

            kernel
                .Bind<ICanUpdateContactDetails>()
                .To<CanUpdateContactDetails>()
                ;

        }

    }

}