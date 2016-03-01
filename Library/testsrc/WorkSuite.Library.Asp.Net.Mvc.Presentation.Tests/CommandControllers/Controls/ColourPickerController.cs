using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourRequestField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Colour.Validators;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.CommandControllers.Controls
{
    public class ColourPickerController : Controller
    {

        public ActionResult PresentNullValue()
        {
            var editor = new Editor()
            {
                id = "colourpickermockform",
                title = "A colour picker mock form",

                actions = new List<RoutedAction> {
                    new RoutedAction {
                        id = "ColourPickerForm",
                        title = "Submit",
                        name = "ColourPickerForm",
                        url = Url.RouteUrl("ColourPickerMockController")
                    }
                },
                fields = new List<Field> {
                    new ARgbColourRequestField()
                    {
                        value = new RGBColourRequest(),
                        property_name = "colour",

                    }
                }
            };




            return View("~/Views/ColourPickerMock/Present.cshtml", editor);
        }

        public ActionResult PresentSomeValue()
        {
            var editor = new Editor()
            {
                id = "colourpickermockform",
                title = "A colour picker mock form",

                actions = new List<RoutedAction> {
                    new RoutedAction {
                        id = "ColourPickerForm",
                        title = "Submit",
                        name = "ColourPickerForm",
                        url = Url.RouteUrl("ColourPickerMockController")
                    }
                },
                fields = new List<Field> {
                    new ARgbColourRequestField()
                    {
                        value = new RGBColourRequest()
                        {
                            R = 204,
                            G = 204,
                            B = 203

                        },
                        property_name = "colour",

                    }
                }
            };




            return View("~/Views/ColourPickerMock/Present.cshtml", editor);
        }


        public ActionResult Command(RequestObject request)
        {
            var validation = new RGBColourRequestValidation().execute(request.colour);

            string result = "";

            validation.Match(
                is_valid:
                    (colour_in_rgb_format) =>
                    {
                        result = "Valid " + colour_in_rgb_format;
                    },

                is_not_valid:

                    errors =>
                    {
                        result = "Invalid";
                    }

                );


            return Content(result);
        }



    }

    public class RequestObject
    {
        public RGBColourRequest colour { get; set; }
    }
}
