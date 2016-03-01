using System.Web.Mvc;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.StaticContent.Commands.Update
{
    public class UpdateStaticContentController
                 :Controller{

        public UpdateStaticContentController(IUpdateStaticContents update_static_content)
        {
            _update_static_content = Guard.IsNotNull(update_static_content, "update_static_content");
        }

        public ActionResult SubmitRequest( UpdateStaticContentRequest request )
        {
            var response = _update_static_content.execute(request);
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly IUpdateStaticContents _update_static_content;

                 }
}