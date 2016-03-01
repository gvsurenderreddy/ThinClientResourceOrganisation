namespace WTS.WorkSuite.Library.DomainTypes.Date {

    /// <summary>
    ///   Interface that all the date converters will accept.  Note 
    /// the converters will never mutate a requests state they will
    /// always create a new response.
    /// </summary>
    public interface IDateRequest {

        string year { get; }
        string month {  get; }
        string day { get; }

    }

}