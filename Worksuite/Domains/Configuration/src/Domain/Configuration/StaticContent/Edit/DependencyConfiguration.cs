using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;
using WTS.WorkSuite.Library.Ninject.Configuration;


namespace WorkSuite.Configuration.Domain.Configuration.StaticContent.Edit
{
    public class DependencyConfiguration
        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Bind<IUpdateStaticContents>()
                .To<UpdateStaticContents>();

            kernel.Bind<IGetUpdateStaticContentRequest>()
                .To<GetUpdateStaticContentRequest>();

            kernel.Bind<IcheckUrlExist>()
                .To<IsUrlExistReponse>();
        }
    }
}