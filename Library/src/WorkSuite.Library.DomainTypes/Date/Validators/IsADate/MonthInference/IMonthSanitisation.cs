using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.MonthInference {

    /// <summary>
    ///     Used to sanitisation whether a string is a valid representation
    /// of a month.
    /// </summary>
    public interface IMonthSanitisation {

        /// <summary>
        ///     If it can it will turn the month into a numerical representation
        /// of the month.
        /// </summary>
        /// <param name="value">
        ///     The month that is to be turned into a month
        /// </param>
        /// <returns>
        ///     Nothing if the month that the argument is meant to represent can not 
        /// be determined otherwise it will return an integer that represents that month.
        /// </returns>
       Maybe<int> sanitise
                    ( string value );
    }
}