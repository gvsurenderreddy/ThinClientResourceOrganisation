namespace WTS.WorkSuite.Library.DomainTypes.OrderList {

    /// <summary>
    ///     Index that identifies the position that a particular
    /// element is at in a list.
    /// </summary>
    public interface IListEntryIndex {

         /// <summary>
         ///    The position in the list. The first position is one rather
         /// than the standard zero, this because we display positions to 
         /// users who generally consider one to be the first position in
         /// a list.
         /// </summary>
         int postion { get; set; }

    }

}