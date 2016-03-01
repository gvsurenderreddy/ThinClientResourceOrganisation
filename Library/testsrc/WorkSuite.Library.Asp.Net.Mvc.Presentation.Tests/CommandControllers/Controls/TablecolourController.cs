using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourRequestField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables;
using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.CommandControllers.Controls
{
    public class TablecolourController : Controller
    {

        public ActionResult SelectColour()
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
                        url = Url.RouteUrl("DisplaySelectedColourInTable")
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
            return View("~/Views/ColourPickerMock/TableColourSelection.cshtml", editor);
        }


        public ActionResult DisplayColourInTable(RequestObject request)
        {
            

            var table = new Table
            {
                id = "table id",
                columns = new[] {
                    "Colour",
                },
                rows = new[] {
                    new ATableRow {
                        id = "first row id",
                        url = "first row url",

                        fields = new List<Field> {
                            new ARgbColourField() {
                                id  = "Row 1 field 1 id",
                                title = "Row 1 field 1 title",
                                is_required = true,
                                property_name = "Row 1 field 1 property name",
                                help = "Row 1 field 1 help name",
                                value = new RgbColour(
                                                r: (byte)request.colour.R.Value,
                                                g: (byte)request.colour.G.Value,
                                                b: (byte)request.colour.B.Value 
                                                )
                            },
                        }
                    },                    
                }
            };
            return View("~/Views/ColourPickerMock/TableColourDisplay.cshtml", table);
        }
    }
    
}
public class RequestObject
{
    public RGBColourRequest colour { get; set; }
}
