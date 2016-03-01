using System.Web;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory {

    /// <summary>
    ///    Base implementation of the IPresenter that descends from the 
    /// standard mvc controller so that we have all that functionality
    /// built in.  
    /// 
    ///   The presenter class will be picked up by the 
    /// PresnterAndControllerFactory controller factory without the class 
    /// name having to be Suffixed with 'Controller'
    /// </summary>
    public class Presenter : Controller, IPresenter {}


    /// <summary>
    /// Base class for a presenter that presents a full page and can provide it page_id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageIdentityPresenter<T> : Presenter where T : IPageIdentity
    {

        public PageIdentityPresenter(T pattern_page_identity, 
                                     ICurrentPageIdentityRepository current_page_identity_repository)
        {

            Guard.IsNotNull(current_page_identity_repository, "current_page_identity_repository");
            Guard.IsNotNull(pattern_page_identity, "page_identity");

            current_page_identity_repository.page_model = pattern_page_identity;
        }
    }

    /// <summary>
    /// Base class for a presenter that presents partial views(usually via AJAX)
    /// It uses a default way to get the page identity by requiring that a custom 
    /// header has been set with the id of the page requesting for its partial view resource
    /// </summary>
    public class PartialPageIdentityPresenter : Presenter
    {
        public PartialPageIdentityPresenter(PartialPageIdentity page_identity, 
                                            ICurrentPageIdentityRepository current_page_identity_repository)
        {
            Guard.IsNotNull(current_page_identity_repository, "current_page_identity_repository");
            Guard.IsNotNull(page_identity, "page_identity");

            current_page_identity_repository.page_model = page_identity;
        }
    }

    public class PartialPageIdentity : IPageIdentity
    {
        public string page_id
        {
            get
            {
                //We have a counter-part in our JS code that sets this custom header.
                //I cannot stress how important it is that the custom header is consistent between the JS code and C# code.
                var the_page_id = HttpContext.Current.Request.Headers["WTS-PAGE-IDENTITY"];
                Guard.IsNotNull(the_page_id, "the_page_id");

                return the_page_id;
            }
        }
    }
    
}