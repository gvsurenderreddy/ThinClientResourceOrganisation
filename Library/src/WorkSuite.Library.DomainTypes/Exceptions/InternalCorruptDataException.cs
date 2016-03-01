using System;

namespace WTS.WorkSuite.Library.DomainTypes.Exceptions
{
    /// <summary>
    /// A domain exception that gets thrown when we come across internal corrupt data.
    /// </summary>
    public class InternalCorruptDataException : Exception
    {
        public InternalCorruptDataException(string message) : base(message)
        {
        }
    }
}
