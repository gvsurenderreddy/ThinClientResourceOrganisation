using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.StringField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls {

    public class TablesController 
                    : Controller {

        public ActionResult Index() {

            var table = new Table {
                id = "table id",
                columns = new[] {
                    "Column 1",
                    "Column 2",
                },
                rows = new[] {
                    new ATableRow {
                        id = "first row id",
                        url = "first row url",

                        fields = new List<Field> {
                            new AStringReportField {
                                id  = "Row 1 field 1 id",
                                title = "Row 1 field 1 title",
                                is_required = true,
                                property_name = "Row 1 field 1 property name",
                                help = "Row 1 field 1 help name",
                                value = "Row 1 field 1",
                            },
                            new AStringReportField {
                                id  = "Row 1 field 2 id",
                                title = "Row 1 field 2 title",
                                is_required = true,
                                property_name = "Row 1 field 2 property name",
                                help = "Row 1 field 2 help name",
                                value = "Row 1 field 2",
                            },
                        }
                    },

                    new ATableRow {
                        id = "second row id",
                        url = "second row url",

                        fields = new List<Field> {
                            new AStringReportField {
                                id  = "Row 2 field 1 id",
                                title = "Row 2 field 1 title",
                                is_required = true,
                                property_name = "Row 2 field 1 property name",
                                help = "Row 2 field 1 help name",
                                value = "Row 2 field 1",
                            },
                            new AStringReportField {
                                id  = "Row 2 field 2 id",
                                title = "Row 2 field 2 title",
                                is_required = true,
                                property_name = "Row 2 field 2 property name",
                                help = "Row 2 field 2 help name",
                                value = "Row 2 field 2",
                            },
                        }
                    },
                }
            };
            return View( table );
        }
    }
}
