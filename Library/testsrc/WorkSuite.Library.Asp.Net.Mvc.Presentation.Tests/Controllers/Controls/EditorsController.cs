using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Helpers.Controls;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls {

    public class EditorsController : Controller {

        public ActionResult Index() {

            return View( EditorHelper.create_an_editor() );
        }
    }
}
