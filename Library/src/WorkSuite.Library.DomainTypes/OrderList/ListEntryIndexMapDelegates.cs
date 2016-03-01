namespace WTS.WorkSuite.Library.DomainTypes.OrderList {

    /// <summary>
    ///     Used to get the position from an unknown type
    /// </summary>
    /// <param name="element">
    ///     an instance of the type that the position is to be read from.
    /// </param>
    /// <typeparam name="T">
    ///     the type of element that the position is to be read from.
    /// </typeparam>
    public delegate int GetPositionMap<T>( T element );

    /// <summary>
    ///     Used to set the position on an unknown type
    /// </summary>
    /// <param name="element">
    ///     an instance of the type that the position is to be applied to.
    /// </param>
    /// <param name="position">
    ///     the position that the element should be set to.
    /// </param>
    /// <typeparam name="T">
    ///     the type of element that the position is to be applied to.
    /// </typeparam>
    public delegate void SetPositionMap<T>( T element, int position );

    /// <summary>
    ///     Used to insert an element into a list.  From the perspective of the ordering a list
    /// we are not interested in how this is done we just want to be in charge of when it is done
    /// which is why the delegate does not accept any parameters.
    /// </summary>
    public delegate void InsertElementIntoList( );

    /// <summary>
    ///     Used to remove an element from a list.  From the perspective of the ordering a list
    /// we are not interested in how this is done we just want to be in charge of when it is done
    /// which is why the delegate does not accept any parameters.
    /// </summary>
    public delegate void RemoveElementFromList( );
}
