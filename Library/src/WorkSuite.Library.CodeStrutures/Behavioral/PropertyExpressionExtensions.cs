using System;
using System.Linq.Expressions;
using System.Reflection;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral {

    /// <summary>
    ///     Container for extension methods that can be applied to
    /// property expressions.  A property expression is an expression that
    /// only does one thing, return the value of a property from a model
    /// </summary>
    public static class PropertyExpressionExtensions {

        /// <summary>
        ///     Get the name of the property that is returned from the expression.
        /// </summary>
        /// <typeparam name="S">
        ///     The type of the model that the porperty is defined on.
        /// </typeparam>
        /// <typeparam name="P">
        ///     The type of the property.
        /// </typeparam>
        /// <param name="property_expression">
        ///     The expression that is to be interogated.
        /// </param>
        /// <returns>
        ///   The name of the property that is being returned in the expression.
        /// </returns>
        public static string property_name<S,P>
                                ( this Expression<Func<S, P>> property_expression ) {
            
            var expression_body = property_expression.Body as MemberExpression;

            if ( expression_body != null ) {

                if (expression_body.Member is PropertyInfo) {
                    return expression_body.Member.Name;
                }
            }
            return string.Empty;
        }
    }

}