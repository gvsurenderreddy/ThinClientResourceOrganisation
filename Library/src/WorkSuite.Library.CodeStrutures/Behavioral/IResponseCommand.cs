namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral {

    /* Note - response commands always return a response so R is 
     *        always true.
     * 
     * 
     * P    Q   R   |   
     * F    T   F   |   () -> Q
     * F    T   T   |   () -> Q<R>
     * T    T   F   |   P  -> Q
     */

    /// <summary>
    ///     Command that does not require any parameters to be invoked and will
    /// always return a simple response object. The simple response object has 
    /// no result type. <see cref="Response"/>, the response provided metadata
    /// about the command such as whether it was successful and if not what 
    /// were the errors.
    /// </summary>
    /// <typeparam name="Q">
    ///     The response that that will be returned by command.
    /// </typeparam>
    public interface IResponseCommand<Q> 
                        : ICommand<Q> 
                where Q : Response {}


    /// <summary>
    ///     Command that does not require any parameters to be invoked and will
    /// always return a simple response object. The simple response object has 
    /// no result type. <see cref="Response"/>, the response provided metadata
    /// about the command such as whether it was successful and if not what 
    /// were the errors.
    /// </summary>
    /// <typeparam name="Q">
    ///     The response that that will be returned by command.
    /// </typeparam>
    public interface IResponseCommand<P,Q> 
                        : ICommand<P,Q> 
                where Q : Response {}



    ///// <summary>
    /////     Command that does not require any parameters to be invoked and will
    ///// always return a response object with a results. The response object has 
    ///// provided metadata about the about the command such as whether it was 
    ///// successful and if not what were the errors, it also provides the result 
    ///// of of the command if it was successful.
    ///// </summary>
    ///// <remarks>
    /////     In our architecture these are used for commands that create things
    ///// and they generally return the identity of the thing that they have 
    ///// created.
    ///// </remarks>
    //public interface IResponseCommand<Q,R> 
    //                    : ICommand<Q> 
    //            where Q : Response<R> {}



    ///// <summary>
    /////     Command requires a request  to be invoked and will
    ///// always return a simple response object. The simple response object has 
    ///// no result type. <see cref="Response"/>, the response provided metadata
    ///// about the command such as whether it was successful and if not what 
    ///// were the errors.
    ///// </summary>
    ///// <typeparam name="Q">
    /////     The response that that will be returned by command.
    ///// </typeparam>
    //public interface IResponseCommand<P,Q> 
    //                    : ICommand<P,Q> 
    //            where Q : Response {}


    ///// <summary>
    /////     Command that requires a parameters to invoke the command.  It adds a 
    ///// constraint to what can be returned as a result of invoking the command, 
    ///// it must be <see cref="Response'1{Q}"/> or a descendant of.
    ///// </summary>
    ///// <typeparam name="P">
    /////     Type of the argument that is passed into the execute method.
    ///// </typeparam>    
    ///// <typeparam name="Q">
    /////     Result type returned when the command is executed.  This has been constrained to
    ///// <see cref="Response'1{R}"/>
    ///// </typeparam>    
    ///// <typeparam name="R">
    /////     The type of the result that the command returns.  This is the type that will be used
    ///// for the type of the result property of the <see cref="Response'1{R}"/>
    ///// </typeparam>    
    //public interface IResponseCommand<P,Q,R>
    //                    : ICommand<P,Q>
    //            where Q : Response<R> {}

}