using System;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions
{
    public class DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinitionBuilder<S>
    {
        public DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinitionBuilder<S> title(Func<S, string> dynamic_title_expression)
        {

            defintion.title = dynamic_title_expression;
            return this;
        }

        public DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinitionBuilder<S> name(Func<S, string> dynamic_name_expression)
        {

            defintion.name = dynamic_name_expression;
            return this;
        }

        public DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinitionBuilder<S> add_class(Func<S, string> dynamic_class_expression)
        {

            defintion.classes.Add(dynamic_class_expression);
            return this;
        }

        public DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinitionBuilder<S> url(Func<S, string> dynamic_url_expression)
        {

            defintion.url = new UrlDefinition.DynamicUrlDefinition<S>
            {
                url_expression = dynamic_url_expression,
            };
            return this;
        }

        public DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinitionBuilder<S> url_from_route(Func<S, string> route_name_expression, Func<S, object> route_parameters_expression)
        {

            defintion.url = new UrlDefinition.DynamicRouteUrlDefinition<S>
            {
                route_name_expression = route_name_expression,
                route_parameter_expression = route_parameters_expression,
            };
            return this;
        }


        public void add()
        {
            add_definition(defintion);
        }


        public DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinitionBuilder(Action<DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinition<S>> add_definition_delegate)
        {

            add_definition = Guard.IsNotNull(add_definition_delegate, "add_definition_delegate");

            defintion = new DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinition<S>
            {
                title = m => string.Empty,
                name = m => string.Empty,
                classes = new Collection<Func<S, string>>(),
            };
        }

        private readonly Action<DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinition<S>> add_definition;
        private readonly DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinition<S> defintion;
    }
}