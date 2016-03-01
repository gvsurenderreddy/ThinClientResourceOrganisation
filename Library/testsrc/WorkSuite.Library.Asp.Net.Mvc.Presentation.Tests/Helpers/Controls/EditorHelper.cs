using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.BooleanField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DateRequestField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DocumentField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.FreeTextField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.HiddenField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ImageField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ReadOnlyField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourRequestField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.StringField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.TimeRequestField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Helpers.Controls
{
    public class EditorHelper
    {
        public static Editor create_an_editor()
        {
            return new Editor
            {
                id = "A editor id",
                title = "A editor title",


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
                        id = "field 1 id",
                        title = "field 1 title",
                        is_required = true,
                        property_name = "field 1 property name",
                        help = "field 1 help name",
                    },
                    new AStringReportField {
                        id = "String field id",
                        title = "String field title",
                        is_required = true,
                        property_name = "String field property name",
                        help = "String field help",
                        value = "String field value",
                    },
                    new ABooleanReportField {
                        id = "Checked Boolean field id",
                        title = "Checked Boolean field title",
                        is_required = true,
                        property_name = "Checked Boolean field property name",
                        help = "Checked Boolean field help",
                        value = true,
                    },
                    new ABooleanReportField {
                        id = "Unchecked Boolean field id",
                        title = "Unchecked Boolean field title",
                        is_required = true,
                        property_name = "Unchecked Boolean field property name",
                        help = "Unchecked Boolean field help",
                        value = false,
                    },
                    new AHiddenField {
                        id = "Hidden field id",
                        title = "Hidden field title",
                        is_required = true,
                        property_name = "Hidden field property name",
                        help = "Hidden field help",
                        value = "Hidden field value",
                    },
                    new AReadOnlyField {
                        id = "Readonly field id",
                        title = "Readonly field title",
                        is_required = true,
                        property_name = "Readonly field property name",
                        help = "Readonly field help",
                        value = "Readonly field value",
                    },
                    new AnImageField {
                        id = "Readonly field id",
                        title = "Readonly field title",
                        is_required = true,
                        property_name = "Readonly field property name",
                        help = "Readonly field help",
                        url = "http://static.bbci.co.uk/h4base/0.209.1/img/apple-touch-icon.png",
                    },
                    new ALookupField {
                        id = "Lookup field no values id",
                        title = "Lookup field no values title",
                        is_required = true,
                        property_name = "Lookup field no values property name",
                        help = "Lookup field no values help",
                        lookup_values = new List<LookupValue> {}
                    },
                    new ALookupField {
                        id = "Lookup field one value id",
                        title = "Lookup field one value title",
                        is_required = true,
                        property_name = "Lookup field one value property name",
                        help = "Lookup field one value help",
                        lookup_values = new List<LookupValue> {
                            new LookupValue {
                                id = "1",
                                description = "Only lookup value",
                            },
                        },
                    },
                    new ALookupField {
                        id = "Lookup field multiple values id",
                        title = "Lookup field multiple values title",
                        is_required = true,
                        property_name = "Lookup field multiple values property name",
                        help = "Lookup field multiple values help",
                        lookup_values = new List<LookupValue> {
                            new LookupValue {
                                id = "1",
                                description = "First lookup value",
                            },
                            new LookupValue {
                                id = "2",
                                description = "Second lookup value",
                            },
                        },
                    },
                    new AFreeTextStringReportField {
                        id = "FreeText field multiple values id",
                        title = "FreeText field title",
                        is_required = true,
                        property_name = "FreeText field property name",
                        help = "FreeText field help",
                        value = "FreeText field value",
                    },
                    new ADocumentField {
                        id = "Document field multiple values id",
                        title = "Document field title",
                        is_required = true,
                        property_name = "Document field property name",
                        help = "Document field help",
                        value = "Document field value",
                    },
                    new ADateRequestField {
                        id = "Date of birth field multiple values id",
                        title = "Date of birth field title",
                        is_required = true,
                        property_name = "Date of birth field property name",
                        help = "Date of birth field help",
                        value = new DateRequest {
                            day = "24",
                            month = "08",
                            year = "2003",
                        }
                    },
                    new ATimeRequestField {
                        id = "Time field multiple values id",
                        title = "Time field title",
                        is_required = true,
                        property_name = "Time field property name",
                        help = "Time field help",
                        value = new TimeRequest {
                            hours = "24",
                            minutes = "08"
                        }
                    },
                     new ARgbColourRequestField() {
                        id = "colour field multiple values id",
                        title = "Time field title",
                        property_name = "colour field property name",
                        value = new RGBColourRequest()
                        {
                             R = 204,
                             G = 25,
                             B = 48
                        }
                    },

                       new ARgbColourField() {
                        id = "colour field multiple values id",
                        title = "colour field title",
                        property_name = "colour field property name", 
                        value = new RgbColour(34,23,78){}
                       }
                }
            };
        }
    }
}