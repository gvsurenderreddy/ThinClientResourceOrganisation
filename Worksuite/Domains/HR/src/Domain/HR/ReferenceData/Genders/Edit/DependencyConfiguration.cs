﻿using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IGetUpdateGenderRequest>()
                .To<GetUpdateGenderRequest>()
                ;

            kernel
                .Bind<IUpdateGender>()
                .To<UpdateGender>()
                ;
        }
    }
}