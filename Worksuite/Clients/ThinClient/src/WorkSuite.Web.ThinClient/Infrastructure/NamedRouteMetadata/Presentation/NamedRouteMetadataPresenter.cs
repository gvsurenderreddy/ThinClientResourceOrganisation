using System.Web.Mvc;
using Newtonsoft.Json;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.NamedRouteMetadataRepository;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure.NamedRouteMetadata.Presentation
{
    public class NamedRouteMetadataPresenter : Presenter
    {
        /// <summary>
        /// A pure JSON or JSONP api endpoint.
        /// </summary>
        /// <param name="callback">The name of the function to pad the JSON data with</param>
        /// <returns>A JSON object with padding</returns>
        public ActionResult Data(string callback = null)
        {
            if (!string.IsNullOrWhiteSpace(callback))
            {
                var data = JsonConvert.SerializeObject(repository.entries);

                var jsonp = string.Format("{0}({1});", callback, data);

                return JavaScript(jsonp);
            }
            else
            {
                return Json(repository.entries, JsonRequestBehavior.AllowGet);
            }
            
        }


        public NamedRouteMetadataPresenter(INamedRouteMetadataRepository the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly INamedRouteMetadataRepository repository;
    }
}