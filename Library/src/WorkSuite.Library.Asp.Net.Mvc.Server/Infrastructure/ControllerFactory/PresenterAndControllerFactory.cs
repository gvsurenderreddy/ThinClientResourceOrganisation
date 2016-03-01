using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory {

    /// <summary>
    ///     Controller factory that allows us register controllers that end
    /// with Presenter.
    /// </summary>
    /// <remarks>
    ///     The controller factory that comes with the mvc framework controller
    /// classes will have a 'Controller' suffix.
    /// 
    /// i.e. GetControllerType will suffix 'Controller' to the argument 
    /// supplied in the controller_name context.
    /// 
    ///     This is a quick implementation that will allow presenter to be 
    /// registered by first checking to see if there is a presenter class that 
    /// matches the controller_name argument.  If not it will use the standard 
    /// controller factories look mechanism.
    /// 
    /// </remarks>

    // to do:  (refactoring) For speed of implementation I used inheritance 
    //         really I should have used composition and the chain of 
    //         responsibility pattern.  

    // to do:  (refactoring) This really should have look the presenters up
    //         in a repository that is injected in.
   
    public class PresenterAndControllerFactory : DefaultControllerFactory {

        /// <remarks>
        ///     If there is a presenter that matches the controller_name it 
        /// returns that otherwise it uses the default controller factory
        /// </remarks>
        /// <inheritdoc/>
        protected override Type GetControllerType
              ( RequestContext request_context
              , string controller_name ) {
            
            var controller = base.GetControllerType( request_context, controller_name );

            return controller ?? GetPresenterType( controller_name );
        }


        // looks to see if there is a present type (type that implements IPresenter ) matching the name
        private Type GetPresenterType ( string presenter_name ) {

            var presenters = new PresenterDictionary();

            return presenters.GetPresenterType( presenter_name );
        }
    }
}