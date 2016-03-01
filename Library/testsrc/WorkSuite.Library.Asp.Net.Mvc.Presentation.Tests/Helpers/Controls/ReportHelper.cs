using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.BooleanField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DefinitionListField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ImageField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.MultiLineFields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.SimpleImageField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.StringField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;
using WTS.WorkSuite.Library.DomainTypes.DefinitionList;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Helpers.Controls
{
    public class ReportHelper
    {
        public static Report create_a_report()
        {
            return new Report
            {
                id = "A report id",
                title = "A report title",
                report_presenter_url = "report_presenter_url",
                report_reorder_url = "report_reorder_url",
                actions = new List<RoutedAction> {
                    new RoutedAction {
                        id = "Action id",
                        title = "Action title",
                        name = "Action id type",
                        url = "url",
                    }
                },
                fields = new List<Field> {
                    new Field {
                        id  = "field 1 id",
                        title = "field 1 title",
                        is_required = true,
                        property_name = "field 1 property name",
                        help = "field 1 help name",
                    },
                    new AStringReportField {
                        id  = "field 2 id",
                        title = "field 2 title",
                        is_required = true,
                        property_name = "field 2 property name",
                        help = "field 2 help name",
                        value = "A string field",
                    },
                    new AStringReportField {
                        id  = "humanized string field id",
                        title = "humanized string field title",
                        is_required = true,
                        property_name = "humanized string field property name",
                        help = "humanized string field help name",
                        value = "a_humanize_string_filed_with_underscores_and_lower_case_first_letter",
                        humanize = true,
                    },
                    new ABooleanReportField {
                        id  = "field 3 id",
                        title = "field 3 title",
                        is_required = true,
                        property_name = "field 3 property name",
                        help = "field 3 help name",
                        value = true,
                    },
                    new AnImageField {
                        id  = "field 4 id",
                        title = "field 4 title",
                        is_required = true,
                        property_name = "field 4 property name",
                        help = "field 4 help name",
                        url = "http://static.bbci.co.uk/h4base/0.209.1/img/apple-touch-icon.png",
                    },
                    new ASimpleImageField {
                        id  = "field 4 id",
                        url = "http://static.bbci.co.uk/h4base/0.209.1/img/apple-touch-icon.png",
                    },
                    new AMultilineStringReportField {
                        id  = "field 5 id",
                        title = "field 5 title",
                        is_required = true,
                        property_name = "field 5 property name",
                        help = "field 4 help name",
                        value = new [] {
                            "Line 1", "Line 2",
                        },
                    },

                    new ADefinitionListReportField()
                    {
                        id = "Definition list multiple values id",
                        title = "Definition tiele",
                        property_name = "Definition list field property name",
                        value = new List<DefinitionListElement>
                        {
                           new DefinitionListElement("Title1", "Definition1"),
                           new DefinitionListElement("Title2", "Definition2")
                        }
                    }
                },
                is_marked_as_hidden = false,
            };
        }
    }
}