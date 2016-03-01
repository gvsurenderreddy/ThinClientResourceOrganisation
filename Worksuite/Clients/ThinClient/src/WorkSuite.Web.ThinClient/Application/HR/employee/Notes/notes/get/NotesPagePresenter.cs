using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Notes.notes.get
{
    public class NotesPagePresenter : PageIdentityPresenter<NotesPageIdentity>
    {

        public ActionResult Page()
        {

            return View(@"~\Application\HR\employee\Notes\notes\page\NotesPageView.cshtml");
        }

        public NotesPagePresenter(NotesPageIdentity pattern_page_identity,
            ICurrentPageIdentityRepository current_page_identity_repository)
            :base(pattern_page_identity, current_page_identity_repository)
        {
           
        }
    }


  
}