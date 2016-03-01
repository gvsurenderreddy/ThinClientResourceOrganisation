using System;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral {

    /// <summary>
    ///     Extension methods that are for Func delegates and expressions.
    /// </summary>
    public static class FuncExtensions {

        /// <summary>
        ///     Returns the value from the expression or the default value if the 
        /// expression is null.
        /// </summary>
        /// <typeparam name="R">
        ///     The type that is returned by the expression
        /// </typeparam>
        /// <param name="expression">
        ///     The expression that returns the value
        /// </param>
        /// <param name="default_value">
        ///     The default value that will be returned if the expression is null.
        /// </param>
        /// <returns></returns>
        public static R value_or_default<R>
                            ( this Func<R> expression
                            , R default_value ) {

            return expression != null 
                    ? expression()
                    : default_value
                    ;
        }

        /// <summary>
        ///     Returns the value from the expression or the default value if the 
        /// expression is null.
        /// </summary>
        /// <typeparam name="R">
        ///     The type that is returned by the expression
        /// </typeparam>
        /// <param name="expression">
        ///     The expression that returns the value
        /// </param>
        /// <param name="default_value">
        ///     The default value that will be returned if the expression is null.
        /// </param>
        /// <returns></returns>
        public static Func<P,Q> value_or_default<P,Q>
                                    ( this Func<P,Q> expression
                                    , Q default_value ){

            return expression ?? ( m => default_value );
        }       

    }
}